FSC = '/cygdrive/c/Program Files (x86)/Microsoft Visual Studio/2019/Community/Common7/IDE/CommonExtensions/Microsoft/FSharp/fsc'
# FSC = /cygdrive/c/Program\ Files\ \(x86\)/Microsoft\ SDKs/F\#/4.0/Framework/v4.0/fsc.exe
MFSC = '/cygdrive/c/Program Files/Mono/bin/fsharpc'

all: mono win

mono: main.fs
	$(MFSC) main.fs /target:exe /out:main.exe

win: main.fs
	$(FSC) main.fs /target:exe /out:main.exe
	
clean:
	rm -f main.exe

