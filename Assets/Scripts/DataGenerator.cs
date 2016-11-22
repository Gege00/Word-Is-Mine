using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class DataGenerator : MonoBehaviour {

    public void StartGenerateData() {
        
        GenerateStageData();
        GenerateWordData();
        Application.Quit();
    }

    public void GenerateStageData() {

        for (int i = 0; i <10; i++) {
            Analytics.CustomEvent("StartStage", new Dictionary<string, object> {{"Stage1", true}});

        }
        for (int i = 0; i < 8; i++)
        {
            Analytics.CustomEvent("FinishStage", new Dictionary<string, object> { { "Stage1", true } });

        }
        for (int i = 0; i < 8; i++)
        {
            Analytics.CustomEvent("StartStage", new Dictionary<string, object> { { "Stage1", true } });

        }

        for (int i = 0; i < 5; i++)
        {
            Analytics.CustomEvent("FinishStage", new Dictionary<string, object> { { "Stage2", true } });

        }

        for (int i = 0; i < 3; i++)
        {
            Analytics.CustomEvent("StartStage", new Dictionary<string, object> { { "Stage1", true } });

        }
        for (int i = 0; i < 2; i++) {
            Analytics.CustomEvent("FinishStage", new Dictionary<string, object> { { "Stage2", false } });

        }

    }

    public void GenerateWordData() {

        for (int i = 0; i < 8; i++)
        {
            Analytics.CustomEvent("MissWord", new Dictionary<string, object> { { "6 long", true } });

        }
        for (int i = 0; i < 4; i++)
        {
            Analytics.CustomEvent("MissWord", new Dictionary<string, object> { { "5 long", true } });

        }

        for (int i = 0; i < 4; i++)
        {
            Analytics.CustomEvent("MissWord", new Dictionary<string, object> { { "4 long", true } });

        }
        for (int i = 0; i < 2; i++)
        {
            Analytics.CustomEvent("MissWord", new Dictionary<string, object> { { "3 long", true } });

        }



    }


}
