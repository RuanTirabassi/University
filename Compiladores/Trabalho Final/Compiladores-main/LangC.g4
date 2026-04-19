grammar LangC;


@header {
  namespace LangC.Grammar;
}

prog : INCLUDE '<stdio.h>' preprocessor* function* mainFunction
     ;

preprocessor
    : INCLUDE '<' VAR '>'                       #includeDirective
    | DEFINE VAR expr                        #defineDirective
    ;

mainFunction : INTEGER MAIN '(' ')' rblock #mainFunctionBlock
             ;

function: TYPE=(INTEGER|DOUBLE|BOOLEAN|STRING) VAR '('params')' rblock     # fnWithReturn
          | VOID VAR '('params')' rblock                                    # fnWithoutReturn
          ;

line : atrib EOL
     | input EOL
     | output EOL
     | controlflow
     | loop
     | function
     | callFunction EOL
     ;

atrib : VAR '=' STR  #VariavelExistenteString
     | STRING VAR '=' STR  #VariavelNovaString
     | TYPE=(INTEGER|DOUBLE) VAR '=' expr  #VariavelNova
     | TYPE=(INTEGER|DOUBLE) VAR '=' callFunction  #VariavelNovaFuncao
     | BOOLEAN VAR '=' BOOL  #VariavelNovaBoolean
     | VAR '=' expr #VariavelExistente 
     | VAR '=' BOOL #VariavelExistenteBoolean
     ;

input : SCANF '(' SCANF_FORMAT ',' AMPERSAND VAR ')'   #inputVar
      | GETS '(' VAR ')'       #inputStr
     ;

output: PRINTF '(' STR ')'     #outputStr
      | PRINTF '(' VAR ')'    #outputVar
      | PRINTF '(' expr ')'    #outputExpr
      | PRINTF '(' STR (',' VAR)+ ')' #outputStrVar
      | PUTS '(' VAR ')'       #outputStrLine
      ;

expr : term '+' expr          #exprSum
     | term '-' expr          #exprSub
     | term                   #exprTerm
     ;

term : factor '*' term          #termMult
     | factor '/' term          #termDiv
     | factor '%' term          #termMod
     | factor                 #termFactor
     ;

factor: '(' expr ')'          #factorExpr
      | VAR                   #factorVar
      | NUMD                  #factorNumD
      | NUM                   #factorNum
      | STR                   #factorStr
      ;

controlflow: IF '(' bexpr ')' block    #ifBlock
            | IF '(' bexpr ')' block ELSE block  #ifElseBlock
    ;

loop: WHILE '(' bexpr ')' block    #loopBlock
     | FOR '(' atrib EOL bexpr EOL atrib ')' block #forLoopBlock
     | DO block WHILE '(' bexpr ')' EOL #doWhileBlock
     ;


block: '{' line+ '}'  #blockLine
     ;

rblock:
     '{' rbody '}'                # fnBlockLine
     ;

rbody:
     line                      # fnBodyLine
     | line rbody               # fnBodyLineMore
     | RETURN BOOL EOL       # fnReturnBoolLine
     | RETURN STR EOL           # fnReturnStrLine
     | RETURN expr EOL          # fnReturnExprLine
     | RETURN EOL               # fnReturnLine
     ;
    
bexpr: expr RELOP=(EQ|NE|LT|GT|LE|GE) expr #bexprRelop
     | expr #bexprExpr
     | bexpr AND bexpr                                 #bexprAnd
     | bexpr OR bexpr                                  #bexprOr
     | NOT bexpr                                       #bexprNot
     ;
    

params: TYPE=(INTEGER|DOUBLE|BOOLEAN|STRING) VAR      #uniqueParam         
     | TYPE=(INTEGER|DOUBLE|BOOLEAN|STRING) VAR SEP params  #multipleParams
     |                                       # noneParam          
     ;

paramsCall: factor         # uniqueParamCall
          | factor SEP paramsCall   # multipleParamCall
          |               # noneParamCall
          ;

callFunction: VAR '('paramsCall')'         #funcInvoc
            ;


//TOKENS
DEFINE: '#define';
INCLUDE : '#include';
MAIN : 'main';
DO : 'do';
WHILE : 'while';
FOR : 'for';
RETURN : 'return';
IMPORT : '#import';
STRUCT : 'struct';
UNION : 'union';
TYPEOF : 'typeof';
IF : 'if';
ELSE : 'else';
SWITCH : 'switch';
CASE : 'case';
BREAK : 'break';
DEFAULT : 'default';
EOL : ';';
PRINTF : 'printf';
SCANF : 'scanf';
SCANF_FORMAT: '"%d"' | '"%f"' | '"%s"';
AMPERSAND   : '&';
GETS : 'gets';
PUTS : 'puts';
INTEGER : 'int';
DOUBLE : 'double';
BOOLEAN : 'bool';
STRING : 'str';
VOID : 'void';
SUM : '+';
SUB : '-';
DIV : '/';
MULT : '*';
MOD : '%';
ASSIGN : '=';
SEP : ',';
LP : '(';
RP : ')';
LB : '{';
RB : '}';
LE : '<=';
LT : '<';
GT : '>';
GE : '>=';
EQ : '==';
NE : '!=';
AND : '&&';
OR  : '||';
NOT : '!';
NUMD : [0-9]+ '.' [0-9]+;
BOOL : 'true' | 'false';
NUM: [0-9]+;
VAR : [a-zA-Z_][a-zA-Z0-9_]*;
STR : '"' (~["\\] | '\\' .)* '"';
COMMENT: '//' ~[\r\n]* -> skip;
COMMENT_BLOCK: '/*' .*? '*/' -> skip; 
WS : [ \t\n\r]+ -> skip;
