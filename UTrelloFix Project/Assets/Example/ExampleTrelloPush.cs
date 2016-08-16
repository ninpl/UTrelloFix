using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;
using Trello;

public class ExampleTrelloPush : MonoBehaviour
{

    // Use this for initialization
    IEnumerator Start()
    {

        var trello = new Trello.Trello("YOUR - KEY", "YOUR - TOKEN");

        // Async, do not block
        yield return trello.populateBoards();
        trello.setCurrentBoard("Your Game");

        // Async, do not block
        yield return trello.populateLists();
        trello.setCurrentList("Achievements");

        var card = trello.newCard();
        card.name = "Unity Test";
        card.desc = "Description";
        card.due = "11/12/2014";

        yield return trello.uploadCard(card);

        // You can use the helper method to upload exceptions with relevant data
        try
        {
            throw new UnityException("Testing");
        }
        catch (UnityException e)
        {
            trello.uploadExceptionCard(e);
        }

    }
}
