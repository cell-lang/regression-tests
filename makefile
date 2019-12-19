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

tests.dll:
	rm -rf tmp/ ; mkdir tmp/
	dotnet run --project ../csharp/dotnet/ project.txt tmp/
	mv tmp/*.cs dotnet/
	dotnet build dotnet/

mixed-tests.dll:
	rm -rf tmp/ ; mkdir tmp/
	dotnet run --project ../csharp/dotnet/ -d -g mixed/project.txt tmp/
	#java -jar ../csharp/cellcd-cs.jar -d -g mixed/project.txt tmp/
	mv tmp/*.cs dotnet-mixed/
	dotnet build dotnet-mixed/

stdlib-tests.dll:
	rm -rf tmp/ ; mkdir tmp
	dotnet run --project ../csharp/dotnet/ -d stdlib/project.txt tmp/
	mv tmp/generated.cs dotnet-stdlib/
	dotnet build dotnet-stdlib/

tests.jar:
	rm -rf tmp/ ; mkdir tmp ; mkdir tmp/gen/
	java -jar ../java/bin/cellcd-java.jar project.txt tmp/gen/
	javac -g -d tmp/ tmp/gen/*.java
	jar cfe tmp/tests.jar net.cell_lang.Generated -C tmp net/

mixed-tests.jar:
	rm -rf tmp/ ; mkdir tmp ; mkdir tmp/gen/
	# java -jar ~/bin/cellc-java.jar mixed/project.txt tmp/gen/
	java -jar ../java/bin/cellcd-java.jar -g mixed/project.txt tmp/gen/
	javac -g -d tmp/ tmp/gen/*.java mixed/*.java
	jar cfe tmp/mixed-tests.jar net.cell_lang.Main -C tmp net

stdlib-tests.jar:
	rm -rf tmp/ ; mkdir tmp ; mkdir tmp/gen/
	java -jar ../java/bin/cellcd-java.jar stdlib/project.txt tmp/gen/
	javac -g -d tmp/ tmp/gen/*.java
	jar cfe tmp/stdlib-tests.jar net.cell_lang.Generated -C tmp net/

clean:
	@rm -rf tmp/ debug/ generated.* Generated.* dump-*.txt interfaces.txt
	@rm -rf dotnet/generated.cs dotnet/facades.cs dotnet/bin/ dotnet/obj/
	@rm -rf dotnet-mixed/generated.cs dotnet-mixed/facades.cs dotnet-mixed/bin/ dotnet-mixed/obj/
	@rm -rf dotnet-stdlib/generated.cs dotnet-stdlib/bin/ dotnet-stdlib/obj/
	@mkdir debug
	@touch debug/stack-trace.txt

################################################################################

update-tests.jar:
	rm -rf tmp/tests.jar tmp/net
	javac -g -d tmp/ tmp/gen/*.java
	jar cfe tmp/tests.jar net.cell_lang.Generated -C tmp net/

update-mixed-tests.jar:
	rm -f tmp/mixed-tests.jar
	javac -g -d tmp/ tmp/gen/*.java mixed/*.java
	jar cfe tmp/mixed-tests.jar net.cell_lang.Main -C tmp net
