using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private IEnumerator coroutine;
    [SerializeField] Slider rotate_x_slider;
    [SerializeField] Slider rotate_y_slider;
    [SerializeField] Slider rotate_z_slider;

    [SerializeField] Slider transform_x_slider;
    [SerializeField] Slider transform_y_slider;
    [SerializeField] Slider transform_z_slider;


    // Start is called before the first frame update
    Matrix4x4 m = new Matrix4x4();
    Vector3 position = new Vector3(0, 0, 0);
    Quaternion rotation = Quaternion.Euler(0, 0, 0);
    Vector3 scale = new Vector3(1, 1, 1);

    float prev_x = 0;
    float prev_y = 0;
    float prev_z = 0;

    float prev_x_transform = 0;
    float prev_y_transform = 0;
    float prev_z_transform = 0;


    float x = 0;
    float y = 0;
    float z = 0;

    float x_transform = 0;
    float y_transform = 0;
    float z_transform = 0;

    void Start()
    {
        // init matrix
        m = m.Init_Matrix(position, rotation, scale);
        transform.FromMatrix(m);

       // float frustumWidth = (2.0f * 5 * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad)) * Camera.main.aspect;
        position = transform.position;

        rotate_x_slider.onValueChanged.AddListener((_x) =>
        {
            float f = _x;
            float delta = f - prev_x;
            prev_x = f;
            x = f;

            rotation = Quaternion.Euler(x, y, z);

            m = m.Get_TRS_Matrix(position, rotation, scale);

            Debug.Log(m);

            transform.FromMatrix(m);
        });

        rotate_y_slider.onValueChanged.AddListener((_y) =>
        {
            /*float f = _y;
            y = 360 * f;
        

            rotation = Quaternion.Euler(x, y, z);

            m = Matrix4x4.TRS(position, rotation, scale);

            Debug.Log(m);

            transform.FromMatrix(m);*/

            float f = _y;
            float delta = f - prev_y;
            prev_y = f;
            y = f;

            rotation = Quaternion.Euler(x, y, z);

            m = m.Get_TRS_Matrix(position, rotation, scale);

            Debug.Log(m);

            transform.FromMatrix(m);

        });

        rotate_z_slider.onValueChanged.AddListener((_z) =>
        {
            /*float f = _z;
            z = 360 * f;

            rotation = Quaternion.Euler(x, y, z);

            m = m.Get_TRS_Matrix(position, rotation, scale);
            transform.FromMatrix(m);*/

            float f = _z;
            float delta = f - prev_z;
            prev_z = f;
            z = f;

            rotation = Quaternion.Euler(x, y, z);

            m = m.Get_TRS_Matrix(position, rotation, scale);

            Debug.Log(m);

            transform.FromMatrix(m);
        });

        transform_x_slider.onValueChanged.AddListener((_x) =>
        {
            /*  float f = _x;
              Debug.Log(transform.position);
              x = 5 * f;

              position.x = x;

              m = m.Get_TRS_Matrix(position, rotation, scale);
              transform.FromMatrix(m);*/

            float f = _x;
            float delta = f - prev_x_transform;
            prev_x_transform = f;
            x_transform = f;

            position.x = x_transform;

            m = m.Get_TRS_Matrix(position, rotation, scale);
            transform.FromMatrix(m);

        });

        transform_y_slider.onValueChanged.AddListener((_y) =>
        {
            float f = _y;
            float delta = f - prev_y_transform;
            prev_y_transform = f;
            y_transform = f;

            position.y = y_transform;

            m = m.Get_TRS_Matrix(position, rotation, scale);
            transform.FromMatrix(m);
        });

        transform_z_slider.onValueChanged.AddListener((_z) =>
        {
            float f = _z;
            float delta = f - prev_z_transform;
            prev_z_transform = f;
            z_transform = f;

            position.z = z_transform;

            m = m.Get_TRS_Matrix(position, rotation, scale);
            transform.FromMatrix(m);
        });
    }


    // Update is called once per frame
    void Update()
    {
    }


}
