using System.Collections;
using UnityEngine;
using System.Threading;

public class AsteroidSpawner : MonoBehaviour
{
    public EnemyFactory _enemyFactory;
    public Asteroid asteroidPrefab;
    public Comet cometPrefab;
    public Spaceship spaceshipPrefab;
    public float spawnDistance = 12f;
    public float spawnRate = .5f;
    public int amountPerSpawn = 1;
    [Range(0f, 45f)]
    public float trajectoryVariance = 15f;

    private void Start()
    {

        //Из фактори взять создание элемента класса и присвоить переменной
        InvokeRepeating(nameof(SpawnAsteroid), spawnRate, spawnRate);
        //для спавна добавить new Asteroid
        StartCoroutine("WaitAndSpawnCometa");
        StartCoroutine("WaitAndSpawnShip");
    }

    public void SpawnAsteroid()
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;
            spawnPoint += transform.position;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            Vector2 trajectory = rotation * -spawnDirection;
            asteroid.SetTrajectory(trajectory);
        }
    }
    public void SpawnComet(Comet enemyC)
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;
            spawnPoint += transform.position;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Comet comet = Instantiate(enemyC, spawnPoint, rotation);

            Vector2 trajectory = rotation * -spawnDirection;
            comet.SetTrajectory(trajectory);
        }
    }
    public void SpawnShip(Spaceship enemyS)
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;
            spawnPoint += transform.position;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Spaceship spaceship = Instantiate(enemyS, spawnPoint, rotation);

            Vector2 trajectory = rotation * -spawnDirection;
            spaceship.SetTrajectory(trajectory);
        }
    }
    public IEnumerator WaitAndSpawnCometa()
    {
        while (true)
        {
            //var comets = _enemyFactory.CreateComet();
            var comets = cometPrefab;
            yield return new WaitForSeconds(5);
            SpawnComet(comets); // для кометы
        }
    }
    public IEnumerator WaitAndSpawnShip()
    {
        while (true)
        {
            //var ships = _enemyFactory.CreateShip();
            var ships = spaceshipPrefab;
            yield return new WaitForSeconds(10);
            SpawnShip(spaceshipPrefab); // для корабля
        }
    }

}
