using UnityEngine;

public class PlayerShoot : MonoBehaviour //Jounille BubbleShooter-esimerkki LineRendererillä ja Raycast 2D:llä
{
    LineRenderer lineRenderer; // Huom. Width muutettu oletus 1:stä 0.1 Line Renderer-komponentista
    public Transform laser;    // Voisi olla myös private ja hakea childeista..
    RaycastHit2D hit;         

    private void Awake()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>(); //hakee gameobjectin childeista LineRenderer-komponentin
    }

    private void Update()
    {
        RotatePlayer();
        CheckMouseClick(); 
    }

    private void FixedUpdate() //Raycastit yms. fysiikkaan liittyvät tulee olla FixedUpdatessa
    {
        hit = Physics2D.Raycast(transform.position, transform.right);
                                                               
        lineRenderer.SetPosition(0, laser.position); // määritetään säteen alkupiste    

        if (hit)                    
            lineRenderer.SetPosition(1, hit.point);   // määritetään säteen loppupiste     
        
        else        
            lineRenderer.SetPosition(1, transform.right * 100); // muutoin näytetään säde 100 yksikön verran          
    }


    void RotatePlayer()
    {
        //pelaajan pyörityskoodi: https://youtu.be/Geb_PnF1wOk?si=lCzJ7H3LqSfPVTJp
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void CheckMouseClick()
    {
        //hiiren klikkaus tuhoaa printtaa osutun gameobjektin nimen ja tuhoaa sen. 
        if (Input.GetMouseButtonDown(0) && hit)
        {
            print(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject);
        }

    }

}