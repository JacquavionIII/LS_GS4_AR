using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TouchTest : MonoBehaviour
{
    public TMP_Text infoBox;

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current == null) return;

        var primaryTouch = Touchscreen.current.primaryTouch;

        if (primaryTouch.press.isPressed)
        {
            Debug.Log("Pressed primary button.");

            Vector2 touchPos = primaryTouch.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("hit");
                Debug.Log(hit.transform.name + " : " + hit.transform.tag);

                if (hit.transform.tag == "King Richard")
                {
                    infoBox.text = "Born on 08 September 1157, Richard I or better known as Richard The Lionheart/Coeur de Lion was the King of England. He reigned as King from 1189-1199. He is mainly known for his accomplishments as a military leader and warrior, hence the title Lionheart being bestowed upon him. His only descendants are Philip of Cognac, who is the illegitimate son of Richard, born by an unknown woman.";
                }

                if (hit.transform.tag == "Camlann")
                {
                    infoBox.text = "His obsession was so great, he gave Henry of Sully the actual Caliburn [Excalibur] so that he may knight his nephew Arthur with it in 1190. Then in 1191, he appointed Henry of Sully to Abbacy of Glastonbury in hopes of digging up the remains of King Arthur and Guinevere.";
                }

                if (hit.transform.tag == "Freteval")
                {
                    infoBox.text = "Lasting from 1193-1199, the Battle of Fréteval was between King Richard and Philip II of France. On 3 July 1994, Richard had beaten Philip, effectively driving him. Having his archive destroyed, Philip decided to leave his remaining archive in Paris, thus leading to the creation of the French National Library.";
                }

                if (hit.transform.tag == "Massacre")
                {
                    infoBox.text = "The Third Crusade was organised by Philip II of France in association with King Richard I and Emperor Frederick Barbossa to reclaim the Holy Land of Jerusalem after it was captured by Ayyubid sultan Saladin in 1187. During this crusade, King Richard I had more than 2 000 Muslim prisoners of war executed in front of the Ayyubid armies of sultan Saladin in 1191.";
                }

                if (hit.transform.tag == "Time Period")
                {
                    infoBox.text = "Richard the Lionheart lived from 1157-1199, during the Medieval period in Britain history. He died at the age of 41 from an injury sustained in battle while laying siege at Chalûs Charbol. He was shot in the shoulder with a crossbolt and succumbed to his injuries.";
                }

                if (hit.transform.tag == "Info")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
