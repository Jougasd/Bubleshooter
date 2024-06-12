using UnityEngine;

public class PlayerShoot : MonoBehaviour //Jounille BubbleShooter-esimerkki LineRendererill� ja Raycast 2D:ll�
{
    LineRenderer lineRenderer; // Huom. Width muutettu oletus 1:st� 0.1 Line Renderer-komponentista
    public Transform laser;    // Voisi olla my�s private ja hakea childeista..
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

    private void FixedUpdate() //Raycastit yms. fysiikkaan liittyv�t tulee olla FixedUpdatessa
    {
        hit = Physics2D.Raycast(transform.position, transform.right);
                                                               
        lineRenderer.SetPosition(0, laser.position); // m��ritet��n s�teen alkupiste    

        if (hit)                    
            lineRenderer.SetPosition(1, hit.point);   // m��ritet��n s�teen loppupiste     
        
        else        
            lineRenderer.SetPosition(1, transform.right * 100); // muutoin n�ytet��n s�de 100 yksik�n verran          
    }


    void RotatePlayer()
    {
        //pelaajan py�rityskoodi: https://youtu.be/Geb_PnF1wOk?si=lCzJ7H3LqSfPVTJp
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