using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using LangC.Grammar;
using Lang;

namespace LangC;

class Program
{
    static void Main(string[] args)
    {
        var dir = Directory.GetCurrentDirectory();
        string text = File.ReadAllText(dir + "/input.txt");

        // Pré-processador
        var preprocessor = new PreProcessor();
        string preprocessedCode = preprocessor.Process(text);

        AntlrInputStream inputStream = new AntlrInputStream(preprocessedCode.ToString());
        LangCLexer lexer = new LangCLexer(inputStream);
        CommonTokenStream stream = new CommonTokenStream(lexer);
        LangCParser parser = new LangCParser(stream);
        
        //error listener
        LangErrorListener errorListener = new LangErrorListener();
        parser.RemoveErrorListeners();
        parser.AddErrorListener(errorListener);

        //listener
        LangListener langListener = new LangListener();
        parser.RemoveParseListeners();
        parser.AddParseListener(langListener);

        IParseTree? tree = null;
        try
        {
            tree = parser.prog();
            if (errorListener.HasErrors){
                Console.WriteLine("Errors!");
                errorListener.ErrorMessages.ForEach(e => Console.WriteLine(e));
                tree = null;
            }
            if (langListener.HasErrors){
                Console.WriteLine("Semantic Errors!");
                langListener.ErrorMessages.ForEach(e => Console.WriteLine(e));
                tree = null;
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        if (tree != null)
        {
            var langVisitor = new LangVisitor();
            langVisitor.Visit(tree);
        }
    }
}
