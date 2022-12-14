using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.SceneManagement;
using UnityEngine.UI;
>>>>>>> Stashed changes

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float countdown = 120f;
    public float health = 100f;

    public int force = 20;
    public int torque = 60; //12
    public float chargeFactor = 15f;
    public float consumptionFactor = 30f;
    public int movingConsumptionMultiplier = 5;
    
    bool charge = false;
    bool path = false;

    public GameObject healthLight;

    public GameObject extraBateryEffect;
    
    public GameObject led1;
    public GameObject led2;
    public GameObject led3;
    public GameObject led4;
    public GameObject led5;
    public GameObject ledOn;

    public GameObject led1Hub;
    public GameObject led2Hub;
    public GameObject led3Hub;
    public GameObject led4Hub;
    public GameObject led5Hub;

    public Material eGray;
    public Material eGreen;
    public Material eRed;
    public Material eWhite;
    public Material eYellow;

    public GameObject camera1;
    public GameObject camera2;
    public GameObject bateryHub;

<<<<<<< Updated upstream
=======
    [Header ("PAUSA")]
    private bool pauseEnable;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameOverTxt;
    public GameObject winTxt;
    public GameObject timer;

    public AudioSource beep;

    public AudioSource engine;
    bool VEnable;
    bool HEnable;

>>>>>>> Stashed changes
    void Start()
    {
       Time.timeScale = 1;
       Debug.Log ("Presiona W/S para Avanzar o Retroceder, A/D para Rotar y C para cambiar de cámara");
    }

    //void LateUpdate() {}

    void Update()
    {
<<<<<<< Updated upstream
=======
        // MENU DE PAUSA
        if((Input.GetKeyUp(KeyCode.Escape)) && !gameOverMenu.activeSelf)
        {
            if(pauseEnable)
            ResumeGame();
            else
            PauseGame();
        }

        // GAME OVER
        if (health <= 0 || countdown <= 0)
        {
            Time.timeScale = 0;
            gameOverTxt.SetActive(true);
            winTxt.SetActive(false);
            gameOverMenu.SetActive(true);
        }
        
        // EXTRA BATERIA
        if (health > 100)
        {
            extraBateryEffect.SetActive(true);
        }
        else
        {
            extraBateryEffect.SetActive(false);
        }
        
>>>>>>> Stashed changes
        // CUENTA REGRESIVA
        if (countdown > 0 && health > 0)
        {
            if (path == true)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                countdown -= Time.deltaTime * 2;
            }
        }
        if (countdown <= 0)
        {
            countdown = 0f;
            Debug.Log ("SE ACABO EL TIEMPO - GAME OVER");
        }
        
        // CONSUMO DE BATERIA
        if (charge == false)
        {  
            if ((Input.GetAxis("Horizontal")) != 0f || (Input.GetAxis("Vertical")) != 0f)
                {
                    health -= Time.deltaTime / consumptionFactor * movingConsumptionMultiplier;
                }
                else
                {
                    health -= Time.deltaTime / consumptionFactor;
                }
        }  

        // INDICADOR LED DE BATERIA // Un Switch aca generaria mas codigo       
        if (health > 75)
        {
            led1.GetComponent<MeshRenderer> ().material = eRed;
            led2.GetComponent<MeshRenderer> ().material = eYellow;
            led3.GetComponent<MeshRenderer> ().material = eGreen;
            led4.GetComponent<MeshRenderer> ().material = eGreen;

            led1Hub.GetComponent<Image>().color = Color.red;
            led2Hub.GetComponent<Image>().color = Color.yellow;
            led3Hub.GetComponent<Image>().color = Color.green;
            led4Hub.GetComponent<Image>().color = Color.green;
        }
        if (health > 50 && health <= 75)
        {
            led1.GetComponent<MeshRenderer> ().material = eRed;
            led2.GetComponent<MeshRenderer> ().material = eYellow;
            led3.GetComponent<MeshRenderer> ().material = eGreen;
            led4.GetComponent<MeshRenderer> ().material = eGray;

            led1Hub.GetComponent<Image>().color = Color.red;
            led2Hub.GetComponent<Image>().color = Color.yellow;
            led3Hub.GetComponent<Image>().color = Color.green;
            led4Hub.GetComponent<Image>().color = Color.gray;
        }
        if (health > 25 && health <= 50)
        {
            led1.GetComponent<MeshRenderer> ().material = eRed;
            led2.GetComponent<MeshRenderer> ().material = eYellow;
            led3.GetComponent<MeshRenderer> ().material = eGray;
            led4.GetComponent<MeshRenderer> ().material = eGray;

            led1Hub.GetComponent<Image>().color = Color.red;
            led2Hub.GetComponent<Image>().color = Color.yellow;
            led3Hub.GetComponent<Image>().color = Color.gray;
            led4Hub.GetComponent<Image>().color = Color.gray;
        }
        if (health > 0 && health <= 25)
        {
            led1.GetComponent<MeshRenderer> ().material = eRed;
            led2.GetComponent<MeshRenderer> ().material = eGray;
            led3.GetComponent<MeshRenderer> ().material = eGray;
            led4.GetComponent<MeshRenderer> ().material = eGray;

            led1Hub.GetComponent<Image>().color = Color.red;
            led2Hub.GetComponent<Image>().color = Color.gray;
            led3Hub.GetComponent<Image>().color = Color.gray;
            led4Hub.GetComponent<Image>().color = Color.gray;
        }
        if (health <= 0)
        {
            led1.GetComponent<MeshRenderer> ().material = eGray;
            led2.GetComponent<MeshRenderer> ().material = eGray;
            led3.GetComponent<MeshRenderer> ().material = eGray;
            led4.GetComponent<MeshRenderer> ().material = eGray;

            led1Hub.GetComponent<Image>().color = Color.gray;
            led2Hub.GetComponent<Image>().color = Color.gray;
            led3Hub.GetComponent<Image>().color = Color.gray;
            led4Hub.GetComponent<Image>().color = Color.gray;

            ledOn.GetComponent<MeshRenderer> ().material = eGray;
        }

        // CAMBIO DE CAMARA
        if(Input.GetKeyUp(KeyCode.C))
        {
            ChangeCamera();
        }

        // UPDATE LIGHT        
        healthLight.GetComponent<Light>().range = health;
        healthLight.GetComponent<Light>().intensity = health / 10;       

        SoundMovement();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

   // :: INPUTS MOVIMIENTOS ::

    /*
    void PlayerMovement()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        Vector3 inputPlayer = new Vector3(movX,0,movY);
        rb.AddTorque(inputPlayer * speed * Time.fixedDeltaTime);
    }
    */

    void PlayerMovement()
    {
        if (countdown > 0 && health > 0)
        {
            float r = Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(0,torque * Time.fixedDeltaTime * r,0));
            //rb.AddTorque(new Vector3(0,torque * Time.fixedDeltaTime * r,0), ForceMode.Impulse); //LAST
            //transform.localRotation = Quaternion.Euler(0,torque * Time.fixedDeltaTime * r,0);
            //transform.Rotate(new Vector3(0,torque * Time.fixedDeltaTime * r,0));
            float v = Input.GetAxis("Vertical");
            //rb.AddForce(new Vector3(0,0,force * Time.fixedDeltaTime * v), ForceMode.Impulse);
            rb.AddForce(transform.forward * force * Time.fixedDeltaTime * v, ForceMode.Impulse);
        }
    }

    void SoundMovement()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if(!VEnable)
            {
                HEnable = true;
                engine.Play();
            }
        }

        if (Input.GetButtonDown("Vertical"))
        {
            if(!HEnable)
            {
                VEnable = true;
                engine.Play();
            }
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            HEnable = false;

            if (!VEnable)
            {
                engine.Pause();
            }
        }

        if (Input.GetButtonUp("Vertical"))
        {
            VEnable = false;

            if (!HEnable)
            {
                engine.Pause();
            }
        }
    }

    // :: SONIDO MOVIMIENTO ::

    

    // Profe Marcos
    /*
    public class Tank : MonoBehaviour
{
    public GameObject cannonTransform;
    public float speed = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTank();
    }

    void moveTank()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0,0,ver) * speed);
        transform.Rotate(new Vector3(0,hor,0) * speed);

        if(Input.GetKey(KeyCode.Q))
        {
            cannonTransform.transform.Rotate(0,-5,0);
        }

        if(Input.GetKey(KeyCode.E))
        {
            cannonTransform.transform.Rotate(0,5,0);
        }

    }
}
*/

    // :: CARGA DE BATERIA / SEGUIMIENTO DE LINEA ::
    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("ChargingBase"))
        {
            if (health > 0 & health < 100)
            {
                health += Time.deltaTime * chargeFactor;
                if (health > 100)
                {
                    health = 100;
                }
            }
            charge = true;
            Debug.Log ("CARGANDO BATERIA");
        }

        if (col.CompareTag("Line"))
        {
            path = true;
            Debug.Log ("EN RUTA");
            if (health > 0)
            {
                led5.GetComponent<MeshRenderer> ().material = eWhite;
                led5Hub.GetComponent<Image>().color =  new Color32(48,251,221,100);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Batery"))
        {
            col.gameObject.SetActive(false);
            health +=50;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("ChargingBase"))
        {
            charge = false;
            Debug.Log ("");
        }

        if (col.CompareTag("Line"))
        {
            path = false;
            Debug.Log ("FUERA DEL CAMINO");
            led5.GetComponent<MeshRenderer> ().material = eGray;
            led5Hub.GetComponent<Image>().color = Color.gray;
        }
    }
    
    // :: SISTEMA DE DAÑO ::
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            Damage(5);
        }

        if (col.gameObject.CompareTag("Obstacle"))
        {
            Damage(10);
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            Damage(15);
        }
    }

    void Damage(int damage)
    {
        health = health - damage;
        if (health > 0){            
            Debug.Log ("BATERIA -" + damage + "%");
        }
        else { 
            Debug.Log ("BATERIA AGOTADA - GAME OVER");
            led5.GetComponent<MeshRenderer> ().material = eGray;
            led5Hub.GetComponent<Image>().color = Color.gray;
            beep.volume = 0;
        }
    }

    // :: CAMBIO DE CAMARA ::
    void ChangeCamera()
    {
        if (camera1.activeInHierarchy == true)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            bateryHub.SetActive(true);
        }
        else
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            bateryHub.SetActive(false);
        }
    }

    // TRASH //

    /*
    if (health > 75)
        {
            led1Mat.SetColor("_EmissionColor", Color.red);
            led2Mat.SetColor("_EmissionColor", Color.yellow);
            led3Mat.SetColor("_EmissionColor", Color.green);
            led4Mat.SetColor("_EmissionColor", Color.green);

            //led4mat.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green); //PROBAR
        }
        if (health > 50 && health <= 75)
        {
            led1Mat.SetColor("_EmissionColor", Color.red);
            led2Mat.SetColor("_EmissionColor", Color.yellow);
            led3Mat.SetColor("_EmissionColor", Color.green);
            led4Mat.SetColor("_EmissionColor", Color.black);
        }
        if (health > 25 && health <= 50)
        {
            led1Mat.SetColor("_EmissionColor", Color.red);
            led2Mat.SetColor("_EmissionColor", Color.yellow);
            led3Mat.SetColor("_EmissionColor", Color.black);
            led4Mat.SetColor("_EmissionColor", Color.black);
        }
        if (health > 0 && health <= 25)
        {
            led1Mat.SetColor("_EmissionColor", Color.red);
            led2Mat.SetColor("_EmissionColor", Color.black);
            led3Mat.SetColor("_EmissionColor", Color.black);
            led4Mat.SetColor("_EmissionColor", Color.black);
        }
        if (health <= 0)
        {
            led1Mat.SetColor("_EmissionColor", Color.black);
            led2Mat.SetColor("_EmissionColor", Color.black);
            led3Mat.SetColor("_EmissionColor", Color.black);
            led4Mat.SetColor("_EmissionColor", Color.black);
        }
    */
    // START
    /*
    //healthLight = GetComponent<Light>();
       /*
       led1 = GameObject.Find("PH1");
       led2 = GameObject.Find("PH2");
       led3 = GameObject.Find("PH3");
       led4 = GameObject.Find("PH4");
       */
       /*
        Renderer led1Render = led1.GetComponent<Renderer>();
        Material led1Mat = led1Render.material;

        Renderer led2Render = led2.GetComponent<Renderer>();
        Material led2Mat = led2Render.material;

        Renderer led3Render = led3.GetComponent<Renderer>();
        Material led3Mat = led3Render.material;

        Renderer led4Render = led4.GetComponent<Renderer>();
        Material led4Mat = led4Render.material;
        */


}
