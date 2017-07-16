# first download BuildTools_Full.exe from Microsoft and install MSBuild into ...
# /cygdrive/c/Program\ Files\ \(x86\)/MSBuild
#
FSC = /cygdrive/c/Program\ Files\ \(x86\)/Microsoft\ SDKs/F\#/4.0/Framework/v4.0/fsc.exe
MFSC = /cygdrive/c/Program\ Files\ \(x86\)/mono/bin/fsharpc


all: mono win

mono: main.fs
	$(MFSC) main.fs /target:exe /out:main.exe

win: main.fs
	$(FSC) main.fs /target:exe /out:main.exe
	
clean:
	rm -f main.exe

