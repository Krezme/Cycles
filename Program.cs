using System;

namespace Cycles
{
    class Program
    {

        int size;
        bool gameWon = false;
        bool ticTacToeAi;

        //True == X, False == O
        bool playerXorO;

        int randomNum;

        bool turn = true;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.ApplicationAssembly();
        }

        void ApplicationAssembly () 
        {
            EnterShapeSize();
            Square(size);
            Console.WriteLine();
            Triangle(size);
            Console.WriteLine();
            Diamond(size);
            Console.WriteLine();
            Grid(size);
            Console.WriteLine();
            TicTacToeAwake(size);
            Console.ReadLine();
        }

        void EnterShapeSize() {
            try {
                Console.Write("Enter the shape size: ");
                size = Convert.ToInt32(Console.ReadLine());
                if (size < 2){
                    throw new Exception();
                }
            } catch (Exception) {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Enter a number GREATER than 1!");
                Console.ReadLine();
                EnterShapeSize();
            }
        }

        void Square (int n) {
            for (int j = 0; j < n; j++) {
                for (int i = 0; i < n; i++) {
                    Console.Write("#");
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        void Triangle (int n) {
            //Vertical (Y) TopPart
            for (int j = 0; j < n; j++) {
                //Horizontal (X)
                for (int i = 0; i < n; i++) {
                    if (i < (n -1) -j) {
                        Console.Write(" ");
                    }
                    else{
                        Console.Write("#" + " ");
                    }
                }
                Console.Write("\n");
            }
        }

        void Diamond (int n) 
        {
            //Vertical (Y) TopPart
            for (int j = 0; j < n; j++) {
                //Horizontal (X)
                for (int i = 0; i < n; i++) {
                    if (i < (n -1) -j) {
                        
                        Console.Write(" ");
                    }
                    else{
                        Console.Write("#" + " ");
                    }
                }
                Console.Write("\n");
            }
            //Vertical (Y) BottomPart
            for (int j = 1; j < n; j++) {
                //Horizontal (X)
                for (int i = 0; i < n; i++) {
                    if (n -i > n -j) {
                        Console.Write(" ");
                    }
                    else{
                        Console.Write("#" + " ");
                    }
                }
                Console.Write("\n");
            }
        }

        void Grid (int n) {
            for (int j = 1; j < n +1; j++) {
                for (int i = 0; i < n; i++) {
                    if ((j%2) == 0){
                        Console.Write("#" + " ");
                    }
                    else{
                        Console.Write("#" + "#");
                    }
                }
                Console.Write("\n");
            }
        }

        void TicTacToeAwake (int n){
            TicTacToeMode();
            Console.Clear();
            gameWon = false;
            int[] spaces = new int[9];
            string[] position = new string [9] {"00","01","02","10","11","12","20","21","22"};
            // True = X False = O
            turn = true;
            NewTicTacToe(spaces);
            TicTacToeRun(n, spaces, position);
        }

        void TicTacToeRun (int n, int[] spaces, string[] position) {
            
            TicTacToeRender(n, spaces, position);
            WinConditionsTicTacToe(spaces);
            if (!gameWon){
                if (playerXorO && ticTacToeAi){
                    UserInputTicTacToe(n, spaces, position);
                }
                if (ticTacToeAi){
                    ticTacToeAI(n, spaces, position);
                }else {
                    UserInputTicTacToe(n, spaces, position);
                }
                if (!playerXorO && ticTacToeAi){
                    UserInputTicTacToe(n, spaces, position);
                }
                Console.Clear();
                TicTacToeRun(n, spaces, position);
            }
            else if (gameWon){
                RestartTicTacToe(n);
            }
        }

        void WinConditionsTicTacToe(int[] spaces) {

            if ((spaces[0] == 1 && spaces[1] == 1 && spaces[2] == 1) || (spaces[3] == 1 && spaces[4] == 1 && spaces[5] == 1) || (spaces[6] == 1 && spaces[7] == 1 && spaces[8] == 1) || (spaces[0] == 1 && spaces[3] == 1 && spaces[6] == 1) || (spaces[1] == 1 && spaces[4] == 1 && spaces[7] == 1) || (spaces[2] == 1 && spaces[5] == 1 && spaces[8] == 1) || (spaces[0] == 1 && spaces[4] == 1 && spaces[8] == 1) || (spaces[2] == 1 && spaces[4] == 1 && spaces[6] == 1)){
                Console.WriteLine("Player X Wins!");
                gameWon = true;
            }
            if ((spaces[0] == 2 && spaces[1] == 2 && spaces[2] == 2) || (spaces[3] == 2 && spaces[4] == 2 && spaces[5] == 2) || (spaces[6] == 2 && spaces[7] == 2 && spaces[8] == 2) || (spaces[0] == 2 && spaces[3] == 2 && spaces[6] == 2) || (spaces[1] == 2 && spaces[4] == 2 && spaces[7] == 2) || (spaces[2] == 2 && spaces[5] == 2 && spaces[8] == 2) || (spaces[0] == 2 && spaces[4] == 2 && spaces[8] == 2) || (spaces[2] == 2 && spaces[4] == 2 && spaces[6] == 2)){
                Console.WriteLine("Player O Wins!");
                gameWon = true;
            }
        }

        void TicTacToeRender (int n, int[] spaces, string[] position) {
            //Repeat Vertival
            for (int l = 0; l < 3; l++){
                //Vertical Box
                for (int k = 0; k < n +1; k++){
                    //Repeat Horizontal
                    for (int j = 0; j < 3; j++){
                        //Horizontal Box
                        for (int i = 0; i < n*2 +1; i++){
                            //Invisable border between deviders and user entries
                            if ((k == 0 || k == n)) {
                                if (j == 2 && i == n*2){
                                }
                                else if (i == n*2) {
                                    Console.Write("|");
                                }
                                else {
                                    Console.Write(" ");
                                }
                            }
                            else if (k > 0 && k < n){
                                if (i == 0 || i == n*2 -1){
                                    Console.Write(" ");
                                }
                                else if (i == n*2 && j != 2){
                                    Console.Write("|");
                                }
                                else{
                                    for (int h = 0; h < position.Length; h++) {
                                        if (position[h] == l.ToString() + j.ToString()){
                                            if (spaces[h] == 0){
                                                if (i == n*2 && j == 2) {
                                                }
                                                else
                                                {
                                                   Console.Write(" "); 
                                                }
                                            }
                                            else if (spaces[h] == 1){
                                                if (i == n*2 && j == 2) {
                                                }
                                                else
                                                {
                                                   Console.Write("X"); 
                                                }
                                            }
                                            else if (spaces[h] == 2){
                                                if (i == n*2 && j == 2) {
                                                }
                                                else
                                                {
                                                   Console.Write("O"); 
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Console.Write("\n");
                    if (k == n && l != 2){
                        for (int i = 0; i < n*6 +3; i++){
                            if (i == n*6 +2){
                                Console.Write("\n");
                            }
                            else{
                                Console.Write("=");
                            }
                        }
                    }
                }
            }
        }
        
        void NewTicTacToe (int[] n){
            for (int i = 0; i < n.Length; i++){
                n[i] = 0;
            }
        }

        void UserInputTicTacToe (int n, int[] spaces, string[] position) {
            try {
                int userEntry;
                if (!ticTacToeAi){
                    if (turn){
                        Console.Write("Enter Player X's input (1-9): ");
                    }
                    else {
                        Console.Write("Enter Player O's input (1-9): ");
                    }
                    userEntry = Convert.ToInt16(Console.ReadLine());
                }
                else {
                    if (playerXorO){
                        Console.Write("Your turn player X: ");
                        userEntry = Convert.ToInt16(Console.ReadLine());
                    }
                    else {
                        Console.Write("Your turn player O: ");
                        userEntry = Convert.ToInt16(Console.ReadLine());
                    }
                }
                if (turn){
                    if (spaces[userEntry-1] == 0){
                        spaces[userEntry-1] = 1;
                    }
                    else {
                        throw new System.Exception();
                    }
                }
                else{
                    if (spaces[userEntry-1] == 0){
                        spaces[userEntry-1] = 2;
                    }
                    else {
                        throw new System.Exception();
                    }
                }
                ChangeTurn();
                Console.Clear();
                TicTacToeRender(n, spaces, position);
                WinConditionsTicTacToe(spaces);
                if (gameWon){
                    RestartTicTacToe(n);
                }
            }
            catch (Exception){
                Console.WriteLine("Invalid entry!");
                Console.ReadLine();
                UserInputTicTacToe(n, spaces, position);
            }
        }

        void RestartTicTacToe (int n){
            string userInput;
            Console.Write("Do you want to start a new game (Y/N): ");
            userInput = Console.ReadLine();
            if (userInput == "Y" || userInput == "y"){
                TicTacToeAwake(n);
            }
            else if (userInput == "N" || userInput == "n"){
                Environment.Exit(0);
            }
            else{
                Console.WriteLine("Invalid input!");
                Console.ReadLine();
                RestartTicTacToe(n);
            }
        }

        void TicTacToeMode () {
            Console.Write("Would you like to play vs computer (Y/N): ");
            string userInput = Console.ReadLine();
            if (userInput == "Y" || userInput == "y"){
                ticTacToeAi = true;
                XorO();
            }
            else if (userInput == "N" || userInput == "n"){
                Console.WriteLine("Player vs Player!");
                Console.WriteLine("Press ENTER button to continue: ");
                ticTacToeAi = false;
                Console.ReadLine();
            }
            else{
                Console.WriteLine("Invalid input!");
                Console.ReadLine();
                TicTacToeMode();
            }
        }

        void XorO (){
            string userInput;
            Console.Write("Would you like to play with Xs or Os (X/O): ");
            userInput = Console.ReadLine();
            if (userInput == "X" || userInput == "x"){
                playerXorO = true;
            }else if (userInput == "O" || userInput == "o"){
                playerXorO = false;
            }else {
                Console.WriteLine("Invalid input!");
                Console.ReadLine();
                XorO();
            }
        }

        void ticTacToeAI (int n, int[] spaces, string[] position){
            Random();

            if (spaces[randomNum] != 0){
                ticTacToeAI(n, spaces, position);
            }
            else{
                if (turn){
                    spaces[randomNum] = 1;
                }
                else{
                    spaces[randomNum] = 2;
                }
            }
            ChangeTurn();
            Console.Clear();
            TicTacToeRender(n, spaces, position);
            WinConditionsTicTacToe(spaces);
            if (gameWon){
                RestartTicTacToe(n);
            }
        }

        void Random (){
            Random rnd = new Random();
            randomNum = rnd.Next(0,9);
        }

        void ChangeTurn (){
            if (turn){
                turn = false;
            }
            else {
                turn = true;
            }
        }

        //Make a random number generator, link it to the lenght of the spaces array.
        //Make the code to switch between Player vs Player and Player vs Computer.
    }
}
