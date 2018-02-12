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

clean:
	rm -rf tmp/ generated.* dump-*.txt interfaces.txt
