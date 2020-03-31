run-all-tests:
	make -s clean
	make --no-print-directory tests.jar
	java -jar tmp/tests.jar
	@echo ; echo
	make -s clean
	make --no-print-directory mixed-tests.jar
	java -jar tmp/mixed-tests.jar mixed/ > tmp/output.txt
	cmp tmp/output.txt reference/java-0.5.4.txt
	@echo ; echo
	make -s clean
	make --no-print-directory stdlib-tests.jar
	time java -jar tmp/stdlib-tests.jar
	@echo ; echo
	make -s clean
	make --no-print-directory mixed-date-time-tests.jar
	java -jar tmp/mixed-date-time-tests.jar
	@echo ; echo
	make -s clean
	make --no-print-directory tests.dll
	dotnet/bin/Debug/netcoreapp3.1/tests
	@echo ; echo
	make -s clean
	make --no-print-directory mixed-tests.dll
	dotnet-mixed/bin/Debug/netcoreapp3.1/dotnet-mixed mixed > tmp/output.txt
	cmp tmp/output.txt reference/csharp-0.5.4.txt
	@echo ; echo
	make -s clean
	make --no-print-directory stdlib-tests.dll
	time dotnet-stdlib/bin/Debug/netcoreapp3.1/dotnet-stdlib
	@echo ; echo
	make -s clean

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
	../csharp/bin/cellc-cs -d project.txt tmp/
	mv tmp/*.cs dotnet/
	dotnet build dotnet/

mixed-tests.dll:
	rm -rf tmp/ ; mkdir tmp/
	../csharp/bin/cellc-cs -d -g mixed/gen-list.txt mixed/project.txt tmp/
# 	../csharp/cellc-cs -d -g mixed/gen-list.txt mixed/project.txt tmp/
	mv tmp/*.cs dotnet-mixed/
	dotnet build dotnet-mixed/

stdlib-tests.dll:
	rm -rf tmp/ ; mkdir tmp
	dotnet ../csharp/bin/cellc-cs.dll stdlib/project.txt tmp/
	mv tmp/*.cs dotnet-stdlib/
	dotnet build -c Release dotnet-stdlib/

tests.jar:
	rm -rf tmp/ ; mkdir tmp ; mkdir tmp/gen/
	java -jar ../java/bin/cellc-java.jar project.txt tmp/gen/
# 	java -jar ../java/bin/cellcd-java.jar project.txt tmp/gen/
# 	java -jar ../work/cellcd-java.jar project.txt tmp/gen/
	javac -g -d tmp/ tmp/gen/*.java
	jar cfe tmp/tests.jar net.cell_lang.Generated -C tmp net/

mixed-tests.jar:
	rm -rf tmp/ ; mkdir tmp tmp/gen/ tmp/cls/
	java -jar ../java/bin/cellc-java.jar -g mixed/project.txt tmp/gen/
# 	java -jar ../java/bin/cellcd-java.jar -g mixed/project.txt tmp/gen/
	javac -g -d tmp/cls/ tmp/gen/*.java mixed/*.java
	jar cfe tmp/mixed-tests.jar Main -C tmp/cls/ .

stdlib-tests.jar:
	rm -rf tmp/ ; mkdir tmp ; mkdir tmp/gen/
# 	java -jar ../java/bin/cellcd-java.jar stdlib/project.txt tmp/gen/
	java -jar ../java/bin/cellc-java.jar stdlib/project.txt tmp/gen/
	javac -g -d tmp/ tmp/gen/*.java
	jar cfe tmp/stdlib-tests.jar net.cell_lang.Generated -C tmp net/

mixed-date-time-tests.jar:
	rm -rf tmp/ ; mkdir tmp ; mkdir tmp/gen/
	java -jar ../java/bin/cellc-java.jar mixed-date-time/project.txt tmp/gen/
# 	java -jar ../work/cellcd-java.jar mixed-date-time/project.txt tmp/gen/
	javac -g -d tmp/ mixed-date-time/MixedDateTimeTests.java tmp/gen/*.java
	jar cfe tmp/mixed-date-time-tests.jar MixedDateTimeTests -C tmp MixedDateTimeTests.class -C tmp net/

clean:
	@rm -rf tmp/ debug/ generated.* Generated.* dump-*.txt interfaces.txt
	@rm -rf dotnet/*.cs dotnet/bin/ dotnet/obj/
	@rm -rf dotnet-mixed/*.cs dotnet-mixed/bin/ dotnet-mixed/obj/
	@rm -rf dotnet-stdlib/*.cs dotnet-stdlib/bin/ dotnet-stdlib/obj/
	@mkdir debug
	@touch debug/stack-trace.txt

################################################################################

update-tests.jar:
	rm -rf tmp/tests.jar tmp/net
	javac -g -d tmp/ tmp/gen/*.java
	jar cfe tmp/tests.jar net.cell_lang.Generated -C tmp net/

update-mixed-tests.jar:
	rm -rf tmp/mixed-tests.jar tmp/cls/*
	javac -g -d tmp/cls/ tmp/gen/*.java mixed/*.java
	jar cfe tmp/mixed-tests.jar Main -C tmp/cls/ .
