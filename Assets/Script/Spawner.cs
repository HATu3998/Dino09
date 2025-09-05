 using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform highPos;
    [SerializeField] private Transform losPos;
    private float timer = 0;
    [SerializeField] private float spawnRate = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnObtacles();
            timer = 0; 
        }
    }
    private void SpawnObtacles()
    {
        int index = Random.Range(0, obstacles.Length);
        if(index < 2)
        {
            GameObject obstacle = Instantiate(obstacles[index], losPos.position, Quaternion.identity);
        }else if (index == 2)
        {
            GameObject obstacle = Instantiate(obstacles[index],highPos.position, Quaternion.identity);
        }
    }
}
