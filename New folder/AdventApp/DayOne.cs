using System;
using System.Formats.Asn1;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\input.txt";
            string[] lines = File.ReadAllLines(path);

            /*
            *  Day 1 Solutions
            */
            //int numSolution = DayOnePartOne(lines.ToList());
            //int numSolution2 = DayOnePartTwo(lines.ToList());

            //int dayTwoSolutionPartOne = DayTwoPartOne();
            //int dayTwoSolutionPartTwo = DayTwoPartTwo();

            //int dayThreePartOne = DayThreePartOne();

            //int dayFourPartOne = DayFourPartOne();
            //int dayFourPartTwo = DayFourPartTwo();

            //int dayEightPartOne = DayEightPartOne();

            //int dayNinePartOne = DayNinePartOne();
            //int dayNinePartTwo = DayNinePartTwo();

            //int dayElevenPartOne = DayElevenPartOne();
            //int dayElevenPartTwo = DayElevenPartTwo();

            //int dayTwelvePartOne = DayTwelvePartOne();
            //int dayTwelvePartTwo = DayTwelvePartTwo();

        }

        public static int DayOnePartOne(List<String> lines){

            List<int> numberList = new List<int>();
            
            int firstNum = -1;
            int secondNum = -1;

            int parseInt = 0;
            int sum = 0;

            foreach(string line in lines){
                for(int i = 0; i < line.Length; i++){
                    if(int.TryParse(line[i].ToString(), out parseInt)){
                        firstNum = parseInt;
                        parseInt = 0;
                        break;
                    }
                }
                for(int i = line.Length - 1; i >= 0; i--){
                    if(int.TryParse(line[i].ToString(), out parseInt)){
                        secondNum = parseInt;
                        parseInt = 0;
                        break;
                    }
                }
                //Console.WriteLine(int.Parse(firstNum.ToString() + secondNum.ToString()));
                numberList.Add(int.Parse(firstNum.ToString() + secondNum.ToString()));
            }

            foreach(int num in numberList){
                sum += num;
            }
            Console.WriteLine(sum);
            return sum;
        }

        public static int DayOnePartTwo(List<string> lines){

            string newLine;
            List<String> newList = new List<string>();
            int sum = 0;

            foreach(string line in lines){
                newLine = line;
                newLine = newLine.Replace("one", "o1e");
                newLine = newLine.Replace("two", "t2o");
                newLine = newLine.Replace("three", "t3e");
                newLine = newLine.Replace("four", "f4r");
                newLine = newLine.Replace("five", "f5e");
                newLine = newLine.Replace("six", "s6x");
                newLine = newLine.Replace("seven", "s7n");
                newLine = newLine.Replace("eight", "e8t");
                newLine = newLine.Replace("nine", "n9e");

                newList.Add(newLine);
            }

            sum = DayOnePartOne(newList);
            Console.WriteLine(sum);
            return sum;
        }

        public static int DayTwoPartOne(){


            List<int> masterGameIDs = new List<int>();

            int MAX_GREEN = 13;
            int MAX_BLUE = 14;

            string[] tempArray;
            string tempGameNum;
            int gameNum = -1;
            bool failFlag = false;

            string data;
            List<String> dataList = new List<string>();

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day2.txt";
            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines){
                tempArray = line.Split(':');
                tempGameNum = tempArray[0];
                data = tempArray[1];
                
                string[] z = tempGameNum.Split(" ");
                if(int.TryParse(z[1].ToString(), out gameNum)){
                    dataList = data.Split(' ').ToList();
                    int tempNum = -1;
                    string tempColor;

                    for(int i = 0; i < dataList.Count - 1; i++){

                        //Test if is int
                        //If so, check next item
                        if(int.TryParse(dataList[i], out tempNum)){}
                            tempColor = dataList[i+1];

                            /*Basic Checks
                            *
                            * Cubes > 14
                            * If 14, only BLUE. NOT GREEN or RED
                            * If 13, GREEN and BLUE. NOT RED
                            * Else, OK
                            */

                            //Auto-fail no matter the color
                            if(tempNum > 14){
                                failFlag = true;
                                break;
                            }

                            else if(tempNum == MAX_BLUE && (tempColor.Contains("green") || tempColor.Contains("red"))){
                                failFlag = true;
                                break;
                            }
                            else if(tempNum == MAX_GREEN && tempColor.Contains("red")){
                                failFlag = true;
                                break;
                            }
                            else{

                            }
                        }
                        if(!failFlag){
                            Console.WriteLine(gameNum);
                            masterGameIDs.Add(gameNum);
                            failFlag = false;
                        }   
                        failFlag = false;                        
                    }
                }

                int sum = 0;
                foreach(int num in masterGameIDs){
                    sum += num;
                }

            Console.WriteLine(sum);
            return 0;
        }
    
        public static int DayTwoPartTwo(){

            List<int> masterGamePowers = new List<int>();

            int maxRed = 0;
            int maxGreen = 0;
            int maxblue = 0;

            string[] tempArray;
            string tempGameNum;

            string data;
            List<String> dataList = new List<string>();

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day2.txt";
            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines){
                tempArray = line.Split(':');
                tempGameNum = tempArray[0];
                data = tempArray[1];
                dataList = data.Split(' ').ToList();
                int tempNum = -1;
                string tempColor;

                for(int i = 1; i < dataList.Count; i++){

                    if(int.TryParse(dataList[i - 1], out tempNum)){
                        tempColor = dataList[i];

                        if(tempColor.Contains("red")){
                            if(tempNum > maxRed){
                                maxRed = tempNum;
                            }
                        }
                        else if(tempColor.Contains("blue")){
                            if(tempNum > maxblue){
                                maxblue = tempNum;
                            }

                        }
                        else if(tempColor.Contains("green")){
                            if(tempNum > maxGreen){
                                maxGreen = tempNum;
                            }
                        }
                
                    }
                    }
                    masterGamePowers.Add(maxRed*maxGreen*maxblue);
                    maxRed = 0;
                    maxGreen = 0;
                    maxblue = 0;
                
            }

            int sum = 0;
            foreach(int power in masterGamePowers){
                sum += power;
            }
            Console.WriteLine(sum);

            return sum;
        }
    
        public static int DayThreePartOne(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day3.txt";
            string[] lines = File.ReadAllLines(path);

            string numBuilder = "";

            int tempNum;
            int startPoint = 0;
            int endPoint = 0;
            int sumPartNumbers = 0;

            bool numFound = false;

            for(int i = 0; i < lines.Length; i++){
                for(int j = 0; j < lines[i].Length; j++){

                    //Check if current char is a num
                    //Continue scanning until no longer part of num
                    //Scan surroundings for symbol
                    if(int.TryParse(lines[i][j].ToString(), out tempNum)){
                        numFound = true;
                        startPoint = j;
                        numBuilder = numBuilder + lines[i][j];
                        while(numFound){
                            //increment and keep checking
                            j++;
                            if(j < lines[i].Length && numFound){
                                if(int.TryParse(lines[i][j].ToString(), out tempNum)){
                                    numBuilder = numBuilder + lines[i][j];
                                }
                                else{
                                    numFound = false;
                                    endPoint = j - 1;
                                }
                            }
                            else{
                                numFound = false;
                                endPoint = j - 1;
                            }

                        }
                        //At this point, numBuilder should contain the whole number
                        //Start and Endpoint are the start and end indexes on row i
                        //Therefore, lets scan the row above, the current row, and below for the symbols
                        // between [start -1, end +1]

                        Console.WriteLine(numBuilder);
                        if(surroundingStringBuilder(i, startPoint, endPoint, lines)){
                            if(int.TryParse(numBuilder, out tempNum)){
                                sumPartNumbers += tempNum;
                                Console.WriteLine("TRUE");
                            }
                        }
                        else{
                            Console.WriteLine("FALSE");
                        }
                        numBuilder = "";
                        tempNum = 0;

                    } 
                }
            }

            Console.WriteLine(sumPartNumbers);
            return 0;

        }

        public static int DayFourPartOne(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day4.txt";
            string[] lines = File.ReadAllLines(path);
            
            int totalPoints = 0;
            int cardPoints = 1;

            List<String> winningNumbers = new List<string>();
            List<String> yourNumbers = new List<string>();
            String[] splitLine;

            foreach(string line in lines){
                splitLine = line.Split("|");
                
                winningNumbers = splitLine[0].Split(' ').ToList();
                yourNumbers = Array.ConvertAll(splitLine[1].Split(' '), p => p.Trim()).ToList();;

                foreach(string num in yourNumbers){
                    foreach(string winNum in winningNumbers){
                        if(num == winNum && num != ""){
                            cardPoints = cardPoints * 2;
                        }
                    }
                }
                Console.WriteLine(cardPoints);
                if(cardPoints > 1){
                    totalPoints += cardPoints/2;
                }            
                cardPoints = 1;

            }
            Console.WriteLine(totalPoints);
            return 0;
        }

        public static int DayFourPartTwo(){


            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day4.txt";
            string[] lines = File.ReadAllLines(path);
            
            int[] masterCardTotalList = Enumerable.Repeat(1, 204).ToArray();

            int totalPoints = 0;
            int matchingNumbers = 0;
            int tempIndex = 0;
            List<String> winningNumbers = new List<string>();
            List<String> yourNumbers = new List<string>();
            String[] splitLine;

            for(int i = 0; i < lines.Length; i++){
                splitLine = lines[i].Split("|");
                
                winningNumbers = splitLine[0].Split(' ').ToList();
                yourNumbers = Array.ConvertAll(splitLine[1].Split(' '), p => p.Trim()).ToList();;

                foreach(string num in yourNumbers){
                    foreach(string winNum in winningNumbers){
                        if(num == winNum && num != ""){
                            matchingNumbers++;
                        }
                    }
                }
                //Console.WriteLine(matchingNumbers);

                tempIndex = i;
                while(matchingNumbers > 0){

                    if(tempIndex >= lines.Length){
                        break;
                    }
                    masterCardTotalList[tempIndex+1] += masterCardTotalList[i];
                    tempIndex++;
                    matchingNumbers--;
                }
                matchingNumbers = 0;

            }

            foreach(int i in masterCardTotalList){
                totalPoints += i;
            }
            Console.WriteLine(totalPoints);
            return 0;
        }

        public static int DayEightPartOne(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day8.txt";
            string[] lines = File.ReadAllLines(path);
            Dictionary<string, string> allNodes = new Dictionary<string, string>();

            string input = lines[0];
            string left = "";
            string right = "";
            string startingNode = "AAA";
            string currentNode = startingNode;

            string[] nodes = new string[lines.Length - 2];
            string[] tempArray;

            int count = 0;
            int inputPosition = 0;


            Array.Copy(lines, 2, nodes, 0, lines.Length - 2);

            foreach(string line in nodes){
                tempArray = line.Split(" = ");
                left = tempArray[0];
                right = tempArray[1].Substring(1, tempArray[1].Length - 2);
                allNodes.Add(left, right);
            }

            while(currentNode != "ZZZ"){
                string node = allNodes[currentNode];
                string[] tempNodeArray = node.Split(", ");
                if(input[inputPosition] == 'L'){
                    currentNode = tempNodeArray[0];
                    inputPosition++;
                    if(inputPosition > input.Length - 1){
                        inputPosition = 0;
                    }
                    count++;
                }
                else{
                    currentNode = tempNodeArray[1];
                    inputPosition++;
                    if(inputPosition > input.Length - 1){
                        inputPosition = 0;
                    }
                    count++;
                }
            }
            Console.WriteLine(count);
            return 0;
        }

        public static int DayEightPartTwo(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day8.txt";
            string[] lines = File.ReadAllLines(path);
            Dictionary<string, string> allNodes = new Dictionary<string, string>();

            string input = lines[0];
            string left = "";
            string right = "";

            List<String> startingNodes = new List<string>();
            string[] nodes = new string[lines.Length - 2];
            string[] tempArray;

            int count = 0;
            int inputPosition = 0;


            Array.Copy(lines, 2, nodes, 0, lines.Length - 2);

            foreach(string line in nodes){
                tempArray = line.Split(" = ");
                left = tempArray[0];
                if(left.EndsWith('A')){
                    startingNodes.Add(left);
                }
                right = tempArray[1].Substring(1, tempArray[1].Length - 2);
                allNodes.Add(left, right);
            }

            //We need to do more shit here
            foreach(string n in startingNodes){

                string currentNode = n;

                while(!currentNode.EndsWith('Z')){
                    string node = allNodes[currentNode];
                    string[] tempNodeArray = node.Split(", ");
                    if(input[inputPosition] == 'L'){
                        currentNode = tempNodeArray[0];
                        inputPosition++;
                        if(inputPosition > input.Length - 1){
                            inputPosition = 0;
                        }
                        count++;
                    }
                    else{
                        currentNode = tempNodeArray[1];
                        inputPosition++;
                        if(inputPosition > input.Length - 1){
                            inputPosition = 0;
                        }
                        count++;
                    }
                }
            }

            
            Console.WriteLine(count);
            return 0;
        }
        
        public static int DayNinePartOne(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp.txt";
            string[] lines = File.ReadAllLines(path);

            int lastDifference = 0;
            int totalSum = 0;

            foreach(string line in lines){
                int[] numArray = line.Split(' ').Select(int.Parse).ToArray();
                lastDifference = findLastDifference(numArray);
                totalSum += lastDifference + numArray[numArray.Count() - 1];
            }

            Console.WriteLine(totalSum);
            return 0;
        }

        public static int DayNinePartTwo(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp.txt";
            string[] lines = File.ReadAllLines(path);

            int firstDifference = 0;
            int totalSum = 0;

            foreach(string line in lines){
                int[] numArray = line.Split(' ').Select(int.Parse).ToArray();
                firstDifference = findFirstDifference(numArray);
                totalSum += numArray[0] - firstDifference;
            }

            Console.WriteLine(totalSum);
            return 0;
        }

        public static int DayElevenPartOne(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp.txt";
            string[] lines = File.ReadAllLines(path);

            bool matchFlag = true;
            int totalSum = 0;
            int count = 0;

            List<int> colNums = new List<int>();
            List<String> myList = new List<string>();
            List<String> masterList = new List<string>();
            List<Tuple<int, int>> listCoords = new List<Tuple<int, int>>();

            myList = lines.ToList();

            //Check all horizontal rows for the same symbol and insert a duplicate if found
            for (int j = 0; j < myList.Count; j++){
                for(int i = 0; i < myList[j].Length; i++){
                    if(myList[j][i] != myList[j][0]){
                        matchFlag = false;
                    }
                }
                if(matchFlag){
                    myList.Insert(j, myList[j]);
                    j++;
                }
                matchFlag = true;
            }

            //Check all vertical rows for the same
            for(int i = 0; i < myList[0].Length; i++){
                for(int j = 0; j < myList.Count; j++){
                    if(myList[j][i].ToString() == "#"){
                        matchFlag = false;
                        break;
                    }
                }
                //Add a column of all '.'s
                if(matchFlag){
                    colNums.Add(i);
                }
                matchFlag = true;

            }
            
            //Add dots to columns
            foreach(string line in myList){
                masterList.Add(insertDotsAtIndexes(line, colNums));
            }
            
            //Actual problem starts now
            //Create a list of tuples/coords where all the '#'s are.
            for (int i = 0; i < masterList.Count; i++){
                for(int j = 0; j < masterList[i].Length; j++){
                    if(masterList[i][j].ToString() == "#"){
                        listCoords.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            //Go through all tuples and find abs. differences between x and y
            for(int i = 0; i < listCoords.Count; i++){
                for(int j = i; j < listCoords.Count; j++){
                    int a = Math.Abs(listCoords[i].Item1 - listCoords[j].Item1) + Math.Abs(listCoords[i].Item2 - listCoords[j].Item2);
                    totalSum += a;
                    count++;
                }
            }
            Console.WriteLine(totalSum);
            //Console.WriteLine(count);
            
            return 0;
        }

        public static int DayElevenPartTwo(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp.txt";
            string[] lines = File.ReadAllLines(path);

            bool matchFlag = true;
            int totalSum = 0;
            int count = 0;

            List<int> colNums = new List<int>();
            List<int> rowNums = new List<int>();
            List<String> myList = new List<string>();
            List<String> masterList = new List<string>();
            List<Tuple<int, int>> listCoords = new List<Tuple<int, int>>();

            myList = lines.ToList();

            //Check all horizontal rows for the same symbol and insert a duplicate if found
            for (int j = 0; j < myList.Count; j++){
                for(int i = 0; i < myList[j].Length; i++){
                    if(myList[j][i] != myList[j][0]){
                        matchFlag = false;
                    }
                }
                if(matchFlag){
                    rowNums.Add(j);
                }
                matchFlag = true;
            }

            //Check all vertical rows for the same
            for(int i = 0; i < myList[0].Length; i++){
                for(int j = 0; j < myList.Count; j++){
                    if(myList[j][i].ToString() == "#"){
                        matchFlag = false;
                        break;
                    }
                }
                //Add a column of all '.'s
                if(matchFlag){
                    colNums.Add(i);
                }
                matchFlag = true;

            }
            
            //Add dots to columns
            //foreach(string line in myList){
            //    masterList.Add(insertDotsAtIndexes(line, colNums));
            //}
            
            //Actual problem starts now
            //Create a list of tuples/coords where all the '#'s are.
            for (int i = 0; i < myList.Count; i++){
                for(int j = 0; j < myList[i].Length; j++){
                    if(myList[i][j].ToString() == "#"){
                        listCoords.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            //Go through all tuples and find abs. differences between x and y
            for(int i = 0; i < listCoords.Count; i++){
                for(int j = i; j < listCoords.Count; j++){
                    int a = Math.Abs(listCoords[i].Item1 - listCoords[j].Item1) + Math.Abs(listCoords[i].Item2 - listCoords[j].Item2);
                    totalSum += a;
                    foreach(int rowNum in rowNums){
                        if((rowNum > listCoords[i].Item1 && rowNum < listCoords[j].Item1) || (rowNum < listCoords[i].Item1 && rowNum > listCoords[j].Item1)){
                            //totalSum += 1000000;
                            count++;
                        }
                    }
                    foreach(int colNum in colNums){
                        if((colNum > listCoords[i].Item2 && colNum < listCoords[j].Item2) || (colNum < listCoords[i].Item2 && colNum > listCoords[j].Item2)){
                            //totalSum += 1000000;
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(totalSum + " + ");
            Console.WriteLine(count + " * 999999");
            
            return 0;
        }

        public static int DayTwelvePartOne(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day12Sample.txt";
            string[] lines = File.ReadAllLines(path);

            //We need recursive function that attempts to place the bricks into the array indices so that
            //we have a legit configuration.
            //We're also gonna need a function to check validity using \.+ as a regex match

            string input;
            string nums;
            string[] temp;
            int total = 0;

            List<int> numList = new List<int>();

            foreach(string line in lines){
                temp = line.Split(' ');
                input = temp[0];
                nums = temp[1];
                numList = Array.ConvertAll(nums.Split(","), int.Parse).ToList();
                //numList = nums.Split(",")?.Select(Int32.Parse)?.ToList();
                total += placeRocks(input, numList);
            }
            Console.WriteLine(total);
            return 0;
        }

        public static int DayTwelvePartTwo(){

            string path = @"C:\Users\Denis\Documents\Visual Studio Code\Advent-of-Code-2023\New folder\AdventApp\Day12Sample.txt";
            string[] lines = File.ReadAllLines(path);

            //We need recursive function that attempts to place the bricks into the array indices so that
            //we have a legit configuration.
            //We're also gonna need a function to check validity using \.+ as a regex match

            string input;
            string superInput;
            string nums;
            string[] temp;
            int total = 0;

            List<int> numList = new List<int>();

            foreach(string line in lines){
                temp = line.Split(' ');
                input = temp[0];
                nums = temp[1];
                numList = Array.ConvertAll(nums.Split(","), int.Parse).ToList();
                
                List<int> tempNumList = new List<int>(numList);

                superInput = input + "?" + input + "?" + input + "?" + input + "?" + input;

                numList.AddRange(tempNumList);
                numList.AddRange(tempNumList);
                numList.AddRange(tempNumList);
                numList.AddRange(tempNumList);

                total += placeRocks(superInput, numList);
            }
            Console.WriteLine(total);
            return 0;
        }

        public static int placeRocks(string input, List<int> nums){
            
            int total = 0;
            List<int> copyOfNums = new List<int>(nums);
            int num = 0;
            bool fail = false;

            if(copyOfNums.Count > 0){
                num = copyOfNums.First();
            }
            else{
                return 0;
            }   
            copyOfNums.RemoveAt(0);

            //Try and allocate num rocks into input from the left
            //Also allocate a . afterwards as well
            for(int i = 0; i < input.Length; i++){
            
                //If we ever pass over a "#", then the sequence fails
                if(i > 0){
                    if(input[i - 1].ToString() == "#"){
                        Console.WriteLine(total);
                        return total;
                    }
                }

                //Check if rocks fit into slots
                if(num > input.Length - i){
                    Console.WriteLine(total);
                    return total;
                }
                
                else{
                    string substring = input.Substring(i, num);
                    for(int j = 0; j < substring.Length; j++){
                        if(substring[j].ToString() == "."){
                            fail = true;
                            break;
                        }
                    }

                    if(fail){
                        fail = false;
                        continue;
                    }
                    //If we make it here, then the rocks fit
                    //We now need to make sure the next slot is empty
                    
                    //There are no numbers left in the list, this is a successful permutation if there are no more #s afterwards so...
                    string testInput = input.Remove(0, i + num);

                    if(copyOfNums.Count == 0){
                        if(testInput.Contains("#")){
                            continue;
                        }
                        total += 1;
                        continue;
                    }

                    //If there are still numbers, we need to make sure there are still slots
                    if(num + 1 > input.Length - i){
                        continue;
                    }

                    //Next we check if the next element is not a rock
                    if(input[i+num].ToString() == "#"){
                        //This fails, continue along
                        continue;
                    }

                    //If its not a rock we can continue the recursive call sending a substring of the input and a reduced List<int> nums
                    else{
                        //Continue recursion
                        string copyInput;

                        if(copyOfNums.Count == 1){
                            copyInput = input.Remove(0, i + num + 1);
                        }
                        else{
                            copyInput = input.Remove(0, i + num + 1);
                        }
                        
                        total += placeRocks(copyInput, copyOfNums);
                    }
                }
                


            }
            Console.WriteLine(total);
            return total;
        }

        public static bool surroundingStringBuilder(int rowIndex, int startCol, int endCol, string[] lines){

            string surroundingString = "";
            string symbols = "@#$%&*+-/=";
            int start = startCol > 0 ? startCol : 1;
            int length = endCol == lines[rowIndex].Length - 1 ? endCol - startCol + 2 : endCol - startCol + 3;
            if(startCol == 0){
                length--;
            }


            //This isnt great at being readable but,
            //Checks in startCol is 0 and endCol is rowLength - 1
            //If either, dont access array indices out of bounds
            if(rowIndex > 0){
                surroundingString += lines[rowIndex - 1].Substring(start - 1, length); 
            }
            surroundingString += lines[rowIndex].Substring(start - 1, length);
            if(rowIndex < lines.Length - 1){
                surroundingString += lines[rowIndex + 1 ].Substring(start - 1, length);
            }
            
            Console.WriteLine(surroundingString);
            foreach (var item in symbols){
                if (surroundingString.Contains(item)){
                    return true;
                }
            }
            return false;
        }
    
    
        public static int findLastDifference(int[] numArray){

            List<int> newNumArray = new List<int>();
            bool isAllZero = true;
            int lastDifference = 0;

            for(int i = 1; i < numArray.Length; i++){
                newNumArray.Add(numArray[i] - numArray[i-1]);
            }

            //Check for all 0s
            foreach(int value in newNumArray){
                if(value != 0 ){
                    isAllZero = false;
                    break;
                }
            }

            //If not all 0s, recurse
            if(!isAllZero){
                lastDifference = findLastDifference(newNumArray.ToArray());
            }
            else{
                return 0;
            }
            //Add new element, last element + difference from row below
            newNumArray.Add(newNumArray[newNumArray.Count - 1] + lastDifference);

            //If we have all 0s, we've hit the bottom
            return newNumArray[newNumArray.Count - 1];
        }

        public static int findFirstDifference(int[] numArray){

            List<int> newNumArray = new List<int>();
            bool isAllZero = true;
            int lastDifference = 0;

            for(int i = 1; i < numArray.Length; i++){
                newNumArray.Add(numArray[i] - numArray[i-1]);
            }

            //Check for all 0s
            foreach(int value in newNumArray){
                if(value != 0 ){
                    isAllZero = false;
                    break;
                }
            }

            //If not all 0s, recurse
            if(!isAllZero){
                lastDifference = findFirstDifference(newNumArray.ToArray());
            }
            else{
                return 0;
            }
            //Add new element, last element + difference from row below
            newNumArray.Insert(0, newNumArray[0] - lastDifference);

            return newNumArray[0];
        }
    
        public static string insertDotsAtIndexes(string line, List<int> colNums){

            string temp = line;

            for (int i = colNums.Count - 1; i >= 0; i--){
                temp = temp.Insert(colNums[i], ".");
                //Console.WriteLine(temp.Length);
            }

            return temp;
        }
    }
}