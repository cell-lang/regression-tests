tests:
	rm -rf tmp/
	mkdir tmp
	cellc project.txt
	mv generated.* tmp/
	g++ -ggdb -std=c++11 -Itmp tmp/generated.cpp -o tmp/tests

mixed-tests:
	rm -rf tmp/
	mkdir tmp
	cellc mixed/project.txt
	mv generated.* tmp/
	g++ -ggdb -std=c++11 -Itmp mixed/main.cpp mixed/rel-auto-A.cpp tmp/generated.cpp -o tmp/mixed-tests

tests.exe:
	rm -rf tmp/
	mkdir tmp
	cellc-cs.exe project.txt
	mv generated.cs interfaces.txt tmp/
	mcs -nowarn:219 tmp/generated.cs -out:tmp/tests.exe

mixed-tests.exe:
	rm -rf tmp/
	mkdir tmp
	cellc-cs.exe mixed/project.txt
	mv generated.cs interfaces.txt tmp/
	mcs -nowarn:219 mixed/*.cs tmp/generated.cs -out:tmp/mixed-tests.exe

tests.jar:
	rm -rf tmp/
	mkdir tmp
	java -jar ~/bin/cellc-java.jar project.txt
	mv Generated.java tmp/
	# javac -g -d tmp/ tmp/cellc-java.java
	javac -d tmp/ tmp/Generated.java
	jar cfe tmp/tests.jar net.cell_lang.Generated -C tmp net/

mixed-tests.jar:
	rm -rf tmp/
	mkdir tmp
	java -jar ~/bin/cellc-java.jar mixed/project.txt
	mv Generated.java interfaces.txt tmp/
	javac -d tmp/ tmp/Generated.java mixed/*.java
	jar cfe tmp/mixed-tests.jar net.cell_lang.Main -C tmp net

clean:
	@rm -rf tmp/ debug/ generated.* Generated.* dump-*.txt interfaces.txt
	@mkdir debug
	@touch debug/stack-trace.txt
