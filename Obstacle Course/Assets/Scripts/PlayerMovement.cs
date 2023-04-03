using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float _moveSpeed = 10f;
    public float _charHealth = 5f;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GameOver();
    }

    void Movement()
    {
        float xValue = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        transform.Translate(xValue, 0f, zValue);
    }

    public void UpdateHealth()
    {
        _charHealth --;
        healthText.text = _charHealth.ToString();
    }

        private void OnCollisionEnter(Collision other) 
    {
       if(other.gameObject.CompareTag("Obstacle")) 
        {
            UpdateHealth();
        }
    }

    public void GameOver()
    {
        if(_charHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
