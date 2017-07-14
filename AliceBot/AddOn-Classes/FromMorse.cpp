#include <iostream>
#include <sstream>
#include <string>
#include <regex>

//To be linked with C# codes
struct letterAndMorse
{
	char letter;
	const char* morse;
};

const letterAndMorse morseCodes[] {
	{'A',"._"   },{'B',"_..." },{'C',"_._." },{'D',"_.."  },
	{'E',"."    },{'F',".._." },{'G',"__."  },{'H',"...." },
	{'I',".."   },{'J',".___" },{'K',"_._"  },{'L',"._.." },
	{'M',"__"   },{'N',"_."   },{'O',"___"  },{'P',".__." },
	{'Q',"__._" },{'R',"._."  },{'S',"..."  },{'T',"_"    },
	{'U',".._"  },{'V',"..._" },{'W',".__"  },{'X',"_.._" },
	{'Y',"_.__" },{'Z',"__.." },
	{'0',"_____"},{'1',".____"},{'2',"..___"},{'3',"...__"},{'4',"...._"},
  {'5',"....."},{'6',"_...."},{'7',"__..."},{'8',"___.."},{'9',"____."},
	{' ',"  "}
};

const char * getMorseFromChar(const char &character) {
	for(const letterAndMorse &M : morseCodes){
		if(M.letter == character) {return M.morse};}

	return "ERR";
}

char getCharFromMorse(const std::string &morse) {
	for(const letterAndMorse &M : morseCodes){
		if(M.morse == morse) {return M.letter};}
    
	return '\0';
}

//For testing 
int main() {
	std::ios_base::sync_with_stdio(false);

	static std::regex morseDetector("(_|\\.|\\s)+");
	static std::regex textDetector("[\\s[:alnum:]]+");

	for(;;) {
		std::cout << " : ";
		
		static std::string input;
		std::getline(std::cin, input);
        
		if(std::regex_match(input, morseDetector)) {
			static std::stringstream morseStream {input};
            
			std::string morse;
			while(morseStream >> morse)
				{std::cout << getCharFromMorse(morse) << " ";}
		}
		else if(std::regex_match(input, textDetector)){
			for(const char &c : input)
				{std::cout << getMorseFromChar(toupper(c)) << " ";}
		}
		std::cout << "\n\n";
	}
}
