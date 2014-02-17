set FILE=RappJavaFinal.jar
javac src/java/*.java -d src/class
cd src/class
jar cvfm %FILE% manifest.txt *.class
move %FILE% ../../
cd ../../
run.bat %FILE%