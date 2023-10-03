using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public enum Planet {None, Sun, Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptun }

    public Planet currentPlanet;
    
    private bool inPlanet;
    [SerializeField] private Transform spaceShip;
    [SerializeField] private float speed;
    //   [SerializeField] private OrbitMotion spaceshipOrbit;
    [Header("CORE")]
    [SerializeField] private GameObject targetPlanet;
    [SerializeField] private float warnDistance;
    [SerializeField] private float insideDistance;

    private void SetPlanet()
    {
        switch (currentPlanet)
        {
            case Planet.None:
                break;
            case Planet.Sun:
              targetPlanet =  GameObject.Find("Sun");
                break;
            case Planet.Mercury:
                targetPlanet =  GameObject.Find("Mercury");
                break;
            case Planet.Venus:
                targetPlanet =  GameObject.Find("Venus");
                break;
            case Planet.Earth:
                targetPlanet =  GameObject.Find("Earth");
                break;
            case Planet.Mars:
                targetPlanet =  GameObject.Find("Mars");
                break;
            case Planet.Jupiter:
                targetPlanet =  GameObject.Find("Jupiter");
                break;
            case Planet.Saturn:
                targetPlanet =  GameObject.Find("Saturn");
                break;
            case Planet.Uranus:
                targetPlanet =  GameObject.Find("Uranus");
                break;
            case Planet.Neptun:
                targetPlanet =  GameObject.Find("Neptune");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        inPlanet = false;
    }

    private void OnValidate()
    {
        if (!targetPlanet)
        {
            spaceShip.GetComponent<OrbitMotion>().isActive = false;
            SetPlanet();
        }
    }

    private void Update()
    {
        if (!inPlanet && targetPlanet)
        {
            if ( Vector3.Distance(spaceShip.position, targetPlanet.transform.localPosition) <= insideDistance)
            {
                Debug.Log("IM ON PLANET");
                OrbitAct();
            }
            else
            {
                Debug.Log("MOVING");
                spaceShip.localPosition = Vector3.MoveTowards(transform.position, targetPlanet.transform.localPosition,  Time.deltaTime * speed);
            }
        }
    }

    private void OrbitAct()
    {
       //spaceShip.gameObject.AddComponent<OrbitMotion>();
        var spaceshipOrbit = spaceShip.GetComponent<OrbitMotion>();
        var planetmotion = targetPlanet.GetComponent<OrbitMotion>();
        var planetSolar = planetmotion.solarObject;
        spaceshipOrbit.solarObject = new SolarObject();
        Define(spaceshipOrbit.solarObject, planetSolar);
        spaceshipOrbit.orbitProgress = planetmotion.orbitProgress;
        spaceshipOrbit.isActive = true;
        inPlanet = true;
        targetPlanet = null;
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
