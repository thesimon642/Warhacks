using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    //syntax of wave "01102" means, send nothing on first slot, send 2 enemy type 1's on second and third, send nothing on 4th and send enemy type 2 on 
    [SerializeField]
    private SpawnerController mySpawner;
    private readonly WaitForSeconds shortWait = new WaitForSeconds(1);
    
    IEnumerator SendWave(string wavePattern)
    {
        char[] instructions = wavePattern.ToCharArray();
        foreach (char instruction in instructions)
        {
            yield return shortWait;
            if (instruction != '0')
            {    
                int indexInstruction = int.Parse(instruction.ToString()) - 1;
                mySpawner.SpawnEnemy(indexInstruction);
            }
            ProgressBarController.progress += 1f;
        }
        WaveCounter.completedSpawners += 1;
    }

    public void Send(string wavePattern)
    {
        StartCoroutine(SendWave(wavePattern));
    }
}
