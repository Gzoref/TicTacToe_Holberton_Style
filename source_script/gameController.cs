using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;


public class gameController : MonoBehaviour {
    
    public int whoTurn; //0 = Seahorse and 1 = Holberton
    public int turnCount; // counts turns played
    public GameObject[] turnIcons; //displays whos turn
    public Sprite[] playerIcons; // 0 = Seahorse icon and 1 = Holberton icon
    public Button[] tictactoeSpaces; // playable spaces
    public int[] markedSpaces; // id which players mark each space
    public Text winnerText; // winner text sign
    public GameObject[] winningLine; // holds all winnning lines
    public GameObject winnerPanel;
    public int SeahorseScore;
    public int HolbertonScore;
    public Text SeahorseText;
    public Text HolbertonText;


    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }
    void GameSetup()
        {
            whoTurn = 0;
            turnCount = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
            for (int i = 0; i < tictactoeSpaces.Length; i++)
            {
                tictactoeSpaces[i].interactable = true;
                tictactoeSpaces[i].GetComponent<Image>().sprite = null;
            }
            for (int i = 0; i < markedSpaces.Length; i++)
                markedSpaces[i] = -100;
            
        }
    // Update is called once per frame
    void Update(){
        
    }

    public void TicTacToeButton(int WhichNumber)
    {
        tictactoeSpaces[WhichNumber].image.sprite = playerIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;
        
        markedSpaces[WhichNumber] = whoTurn+1;
        
        turnCount++;
        if(turnCount > 4)
        {
            winnerCheck();
        }
        if (whoTurn == 0) 
        {
            whoTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }
    void winnerCheck() 
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];
        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 3*(whoTurn+1))
            {
                winnerDisplay(i);
            }
        }
    }
    void winnerDisplay(int indexIn)
    {
        winnerPanel.gameObject.SetActive(true);
        if(whoTurn == 0)
        {
            winnerText.text = "Seahorse Wins!";
            SeahorseScore++;
            SeahorseText.text = SeahorseScore.ToString();
        }
        else if(whoTurn == 1)
        {
            winnerText.text = "Holberton Wins!";
            HolbertonScore++;
            HolbertonText.text = HolbertonScore.ToString();
        }
        winningLine[indexIn].SetActive(true);
        
    }
    public void Rematch()
    {
        GameSetup();
        for(int i = 0; i < winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
    }
    public void Restart()
    {
        Rematch();
        SeahorseScore = 0;
        HolbertonScore = 0;
        SeahorseText.text = "0";
        HolbertonText.text = "0";
    }
}

