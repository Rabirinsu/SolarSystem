
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
       private bool isInside;
     /*  [SerializeField] private GameObject warnCanvas;
       [SerializeField] private GameObject insideCanvas;
       [SerializeField] private TextMeshProUGUI distance_TMP;*/
       [SerializeField] private Transform spaceShip;
       [SerializeField] private OrbitMotion spaceshipOrbit;
       [Header("CORE")]
       [SerializeField] private GameObject currentPlanet;
       [SerializeField] private float warnDistance;
       [SerializeField] private float insideDistance;
  
       
       public void CheckDistance(GameObject obj, float distancetoPlanet) // Distance form Z axis ? Vector3 ?
       {
              if (Mathf.Abs(spaceShip.position.z - distancetoPlanet) <= insideDistance)
              {
                   //  if(!warnCanvas.activeSelf)
                    // warnCanvas.SetActive(true);
                //     distance_TMP.text = ((int)spaceShip.position.z ).ToString();
                    spaceShip.GetComponent<OrbitMotion>().enabled = true;
              }
           //   else warnCanvas.SetActive(false);
       }
      
       public void CheckDistance()
       {
              var distance = Vector3.Distance(spaceShip.position, currentPlanet.transform.position);
              if (distance <= warnDistance && distance > insideDistance)
              {
                  /*   if(insideCanvas.activeSelf)
                            insideCanvas.SetActive(false);
                     
                     if(!warnCanvas.activeSelf)
                            warnCanvas.SetActive(true);
                  else   distance_TMP.text = ((int)spaceShip.position.z * 100).ToString();*/
                  
              }
              else if (distance <= insideDistance && !spaceshipOrbit.isActive)
              {
                   //  warnCanvas.SetActive(false);
                  //   insideCanvas.SetActive(true);
                  var planetmotion = currentPlanet.GetComponent<OrbitMotion>();
                 var planetSolar = planetmotion.solarObject;
                 spaceshipOrbit.solarObject = new SolarObject();
                 Define(spaceshipOrbit.solarObject, planetSolar);
                 spaceshipOrbit.orbitProgress = planetmotion.orbitProgress;
                 spaceshipOrbit.isActive = true;
                //  spaceShip.transform.position = currentPlanet.transform.position;
                // spaceshipOrbit.solarObject.zAxis += 2.5f;
              }
              
              else if(distance > warnDistance)
              {
                  //   insideCanvas.SetActive(false);
                  //   warnCanvas.SetActive(false);
              }
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

       private void Update()
       {
              CheckDistance();
       }
}
