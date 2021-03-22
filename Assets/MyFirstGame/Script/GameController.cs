using UnityEngine;

namespace MyFirstGame.Script
{
    public class GameController : MonoBehaviour
    {
        
        
        public GameObject enemy;

        private void Start()
        {
            InvokeRepeating("CreateEnemy", 1.2F, 0.7F);
        }

        private void CreateEnemy()
        {
            var newEnemy = Instantiate(enemy);
            var x = Random.Range(-2, 2);
            newEnemy.transform.position = new Vector3(x, 5F, 0F);
        }
    }
}