using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionShopNPC : MonoBehaviour, IPointerClickHandler
{
    // internal properties exposed to editor
    [SerializeField] private string conversationStartNode;

    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;

    private int curDialogue = 1;

    private bool interactable = true;
    private bool isCurrentConversation = false;

    private Image image;

    [SerializeField] private string spritePath;

    //private bool isMarried = false;
    //private int curGold = 0;
    //private int hp = 10;
    //private bool dyingDialogueActivated = false;

    public void Start()
    {
        image = GetComponent<Image>();
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);


    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (interactable && !dialogueRunner.IsDialogueRunning)
        {
            StartConversation();
        }
    }

    private void StartConversation()
    {
        //isCurrentConversation = true;

        //if(curGold < 500)
        //{
        //    dialogueRunner.StartDialogue("I am poor");
        //}
        //else if(hp < 50 && !dyingDialogueActivated)
        //{

        //    dialogueRunner.StartDialogue("I am dying");
        //    dyingDialogueActivated = true;
        //}
        //else if (isMarried)
        //{
        //    int selectedDialogue = Random.Range(1, 5);
        //    if (selectedDialogue == 1)
        //    {
        //        dialogueRunner.StartDialogue("FirstDialogue");

        //    }
        //    else if (selectedDialogue == 2)
        //    {
        //        dialogueRunner.StartDialogue("Second");
        //    }
        //}
        //else
        //{
        //    dialogueRunner.StartDialogue("merchantDefault");
        //}

        if (curDialogue == 1)
        {
            dialogueRunner.StartDialogue("First");
            curDialogue = 2;
        }
        else if (curDialogue == 2)
        {
            dialogueRunner.StartDialogue("Second");
            curDialogue = 1;
        }

    }


    private void EndConversation()
    {
        isCurrentConversation = false;

    }

    //自訂義功能

    [YarnCommand("disable")]
    public void DisableConversation()
    {
        interactable = false;
    }

    [YarnCommand("enable")]
    public void EnableConversation()
    {
        interactable = true;
    }


    [YarnCommand("changeExpression")]
    public void changeExpression(string expression)
    {
        string expressionPath = spritePath + expression;

        Sprite tempSprite = Resources.Load<Sprite>(expressionPath);
        image.sprite = tempSprite;
    }

}