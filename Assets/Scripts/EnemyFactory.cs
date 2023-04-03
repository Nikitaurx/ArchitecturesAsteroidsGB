using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    public Asteroid CreateAsteroid()
    {
        return new Asteroid();
    }
    public Comet CreateComet()
    {
        return new Comet();
    }
    public Spaceship CreateShip()
    {
        return new Spaceship();
    }

}
