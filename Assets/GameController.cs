
using System;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isOrbit;
       [SerializeField] private Transform spaceShip;
    //   [SerializeField] private OrbitMotion spaceshipOrbit;
       [Header("CORE")]
       [SerializeField] private GameObject targetPlanet;
       [SerializeField] private float warnDistance;
       [SerializeField] private float insideDistance;
  
       
       public void MovePlanet(GameObject planet)
       {
           targetPlanet = planet;
       }

     
      

       private void Define( SolarObject spaceshipdata,SolarObject planetdata)
       {
           spaceshipdata.type = Constants.Objects.None;
           spaceshipdata.xAxis = planetdata.xAxis + 3f;
           spaceshipdata.zAxis = planetdata.zAxis + 2.5f;
           spaceshipdata.orbitPeriodSeconds = planetdata.orbitPeriodSeconds;
           spaceshipdata.rotationPeriodSeconds = planetdata.rotationPeriodSeconds;
           spaceshipdata.rotationAngle = planetdata.rotationAngle;
           spaceshipdata.isRotationClockwise = planetdata.isRotationClockwise;
           spaceshipdata.realWorldSimulation = planetdata.realWorldSimulation;
           spaceshipdata.orbitPeriodYears = planetdata.orbitPeriodYears;
           spaceshipdata.rotationPeriodDays = planetdata.rotationPeriodDays;
           spaceshipdata.drawOrbit = planetdata.drawOrbit;
           spaceshipdata.isMoving = planetdata.isMoving;
           spaceshipdata.isRotating = planetdata.isRotating;
       }
}
