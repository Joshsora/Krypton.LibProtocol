lexer grammar KryptonTokens;

IMPORT : 'import' ;
GROUP : 'group' ;
LIBRARY : 'library' ;
PROTOCOL : 'protocol' ;
PACKET : 'packet' ;
DECLARE : 'declare' ;
THIS : 'this' ;
OPTIONS : 'options' -> pushMode(MEMBER_OPTIONS);
KPDL : 'kpdl' ;

BUILTIN_TYPE 
  : BOOL
  | BYTE | SBYTE
  | INT16 | UINT16
  | INT32 | UINT32
  | INT64 | UINT64
  | STRING | CSTRING
  | BUFFER | LIST
  ;

fragment BYTE : 'byte' ;
fragment SBYTE : 'sbyte' ;
fragment BOOL : 'bool' ;
fragment INT16 : 'int16' ;
fragment UINT16 : 'uint16' ;
fragment INT32 : 'int32' ;
fragment UINT32 : 'uint32' ;
fragment INT64 : 'int64' ;
fragment UINT64 : 'uint64' ;
fragment STRING : 'string' ;
fragment CSTRING : 'cstring' ;
fragment BUFFER : 'buffer';
fragment LIST : 'list' ;

TRUE : 'true' ;
FALSE : 'false' ;

GREATER_OR_EQUAL : '>=' ;
LESS_OR_EQUAL : '<=' ;
EQUALITY : '==';
INEQUALITY : '!=' ;
LSHIFT : '<<' ;
RSHIFT : '>>' ;
ADD : '+' ;
SUBTRACT : '-' ;
MULTIPLY : '*' ;
MODULUS : '%' ;
NEGATE : '~' ;
NOT : '!' ;
EXCLUSIVE_OR : '^' ;
INCLUSIVE_OR : '|' ;
RELATIONAL_OR : '||' ;
BINARY_AND : '&' ;
RELATIONAL_AND : '&&' ;

EQUALS : '=' ;
DIRECTIVE : '=>' ;
PERIOD : '.' ;
COMMA : ',' ;
COLON : ':' ;
DOUBLECOLON : '::' ;
SEMICOLON : ';' ;
LSBRACKET : '[' ;
RSBRACKET : ']' ;
LBRACKET : '{' ;
RBRACKET : '}' ;
LPAREN : '(' ;
RPAREN : ')' ;
FSLASH : '/' ;
SINGLEQUOTE : '\'';
DOUBLEQUOTE : '"';
LARROW : '<' ;
RARROW : '>' ;

IDENTIFIER 
    : [A-Za-z_][A-Za-z_0-9]+ 
    ;

FLOAT : [0-9]+.[0-9]+ ;
INTEGER : [0-9]+ ;

// redirect comments to a different channel
KPDL_COMMENT : '#' ~[\r\n]* -> skip ;
LINE_COMMENT : '//' ~[\r\n]* -> channel(HIDDEN) ;
BLOCK_COMMENT : '/*' .*? '*/' -> channel(HIDDEN) ;

// skip whitespace
WS : [ \t\r\n]+ -> skip ;

/**
    Member option lexing
*/
mode MEMBER_OPTIONS;
OPTIONS_ENTER
  : LBRACKET
  ;
 
OPTIONS_EXIT
  : RBRACKET -> popMode 
  ;

OPTION_SET
  : COLON -> pushMode(MEMBER_OPTION)
  ;

OPTION_KEY
  : IDENTIFIER
  ;
 
MEMBER_OPTIONS_WS : WS -> skip ;

mode MEMBER_OPTION;
OPTION_END
  : SEMICOLON -> popMode
  ;

STRING_VAL
  : DOUBLEQUOTE .*? DOUBLEQUOTE
  | SINGLEQUOTE .*? SINGLEQUOTE
  ;

MEMBER_OPTION_WS : WS -> skip ;
