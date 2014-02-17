IF [%1]==[] GOTO BLANK
java -jar %1

:BLANK
set /p jf=Enter the .jar file name: 
java -jar %jf%