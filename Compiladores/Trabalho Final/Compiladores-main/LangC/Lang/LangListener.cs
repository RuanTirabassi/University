using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using LangC.Grammar;

namespace Lang
{
    public class LangListener : LangCBaseListener
    {
        public Dictionary<string, IParseTree> Functions { get; protected set; } = new Dictionary<string, IParseTree>();
        public HashSet<string> Variables { get; private set; } = new HashSet<string>();
        public Dictionary<string, object> LocalVariables { get; private set; } = new Dictionary<string, object>();

        public Boolean HasErrors { get; private set; } = false;
        public List<string> ErrorMessages { get; private set; } = new List<string>();

        struct LocalVariablesAttributs
        {
            public int type;
            public object? value;
            public string name;
            public LocalVariablesAttributs(int _type, object? _value, string _name)
            {
                type = _type;
                value = _value;
                name = _name;
            }

            public int GetType()
            {
                return type;
            }

            public object? GetValue()
            {
                return value;
            }

            public string GetName()
            {
                return name;
            }

            public void SetType(int _type)
            {
                type = _type;
            }

            public void SetValue(object? _value)
            {
                value = _value;
            }

            public void SetName(string _name)
            {
                name = _name;
            }
        }

        public override void ExitVariavelNovaFuncao([NotNull] LangCParser.VariavelNovaFuncaoContext context)
        {
            var varName = context.VAR().GetText();

            if (Variables.Contains(varName)) {
                HasErrors = true;
                ErrorMessages.Add("Variável existente");
            } else 
            {
                Variables.Add(varName);
            }
        }

        public override void ExitVariavelNova([NotNull] LangCParser.VariavelNovaContext context) 
        {
            var varName = context.VAR().GetText();

            if (Variables.Contains(varName)) {
                HasErrors = true;
                ErrorMessages.Add("Variável existente");
            } else 
            {
                Variables.Add(varName);
            }
            
        }

        public override void ExitVariavelNovaString([NotNull] LangCParser.VariavelNovaStringContext context)
        {
            var varName = context.VAR().GetText();
            
            if (Variables.Contains(varName)) {
                HasErrors = true;
                ErrorMessages.Add("Variável existente");
            }
            else {
                Variables.Add(varName);
            }
        }

        public override void ExitVariavelNovaBoolean([NotNull] LangCParser.VariavelNovaBooleanContext context)
        {
            var varName = context.VAR().GetText();
            
            if (Variables.Contains(varName)) {
                HasErrors = true;
                ErrorMessages.Add("Variável existente");
            }
            else {
                Variables.Add(varName);
            }
        }

        public override void ExitVariavelExistenteBoolean([NotNull] LangCParser.VariavelExistenteBooleanContext context)
        {
            var varName = context.VAR().GetText();

            if (!Variables.Contains(varName)) 
            {
                HasErrors = true;
                ErrorMessages.Add("Variável inexistente, crie ela primeiro");
            }
        }

        public override void ExitVariavelExistente([NotNull] LangCParser.VariavelExistenteContext context)
        {
            var varName = context.VAR().GetText();

            if (!Variables.Contains(varName)) 
            {
                HasErrors = true;
                ErrorMessages.Add("Variável inexistente");
            }
        }

        public override void ExitVariavelExistenteString([NotNull] LangCParser.VariavelExistenteStringContext context)
        {
            var varName = context.VAR().GetText();

            if (!Variables.Contains(varName))
            {
                HasErrors = true;
                ErrorMessages.Add("Variável inexistente, crie ela primeiro");
            }
        }

        public override void ExitOutputVar([NotNull] LangCParser.OutputVarContext context)
        {
            var varName = context.VAR().GetText();

            // if (!Variables.Contains(varName)) {
            //     HasErrors = true;
            //     ErrorMessages.Add("Variável inexistente, crie ela antes de utilizar.");
            // }
        }

        public override void ExitOutputStrVar([NotNull] LangCParser.OutputStrVarContext context)
        {
            var variables = context.VAR().Select(varCtx => varCtx.GetText()).ToList();
            foreach (var varName in variables)
            {
                if (!Variables.Contains(varName))
                {
                    HasErrors = true;
                    ErrorMessages.Add("Variável inexistente, crie ela antes de utilizar.");
                }
            }
        }

        public override void ExitInputVar([NotNull] LangCParser.InputVarContext context)
        {
            var varName = context.VAR().GetText();
            
            if (!Variables.Contains(varName)) {
                Variables.Add(varName);
            }
        }

        public override void ExitFnWithReturn([NotNull] LangCParser.FnWithReturnContext context)
        {
            var fnName = context.VAR().GetText();
            
            if (Functions.ContainsKey(fnName))
            {
                HasErrors = true;
                ErrorMessages.Add("Function " + fnName + " already defined");
            } 
            else 
            {
                Functions.Add(fnName, context);
            }
            
        }

        public override void ExitFnWithoutReturn([NotNull] LangCParser.FnWithoutReturnContext context)
        {
            var fnName = context.VAR().GetText();
            
            if (Functions.ContainsKey(fnName))
            {
                HasErrors = true;
                ErrorMessages.Add("Function " + fnName + " already defined");
            } 
            else 
            {
                Functions.Add(fnName, context);
            }
        }
    }
}