
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
       private bool isInside;
       [SerializeField] private GameObject warnCanvas;
       [SerializeField] private GameObject insideCanvas;
       [SerializeField] private TextMeshProUGUI distance_TMP;
       [SerializeField] private Transform spaceShip;
       [Header("CORE")]
       [SerializeField] private GameObject planet;
       [SerializeField] private float warnDistance;
       [SerializeField] private float insideDistance;
  
       
       public void CheckDistance(GameObject planet, float distancetoPlanet) // Distance form Z axis ? Vector3 ?
       {
              if (Mathf.Abs(spaceShip.position.z - distancetoPlanet) <= warnDistance)
              {
                     if(!warnCanvas.activeSelf)
                     warnCanvas.SetActive(true);
                     distance_TMP.text = ((int)spaceShip.position.z ).ToString();
              }
              else warnCanvas.SetActive(false);
       }
      
       public void CheckDistance()
       {
              var distance = Vector3.Distance(spaceShip.position, planet.transform.position);
              if (distance <= warnDistance && distance > insideDistance)
              {
                     if(insideCanvas.activeSelf)
                            insideCanvas.SetActive(false);
                     
                     if(!warnCanvas.activeSelf)
                            warnCanvas.SetActive(true);
                  else   distance_TMP.text = ((int)spaceShip.position.z * 100).ToString();
                  
              }
              else if (distance <= insideDistance)
              {
                     warnCanvas.SetActive(false);
                     insideCanvas.SetActive(true);
              }
              else if(distance > warnDistance)
              {
                     insideCanvas.SetActive(false);
                     warnCanvas.SetActive(false);
              }
       }
       

       private void Update()
       {
              CheckDistance();
       }
}
