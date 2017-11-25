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
	g++ -ggdb -std=c++11 -Itmp mixed/main.cpp mixed/tr-auto-A.cpp tmp/generated.cpp -o tmp/mixed-tests

clean:
	rm -rf tmp/ generated.*
