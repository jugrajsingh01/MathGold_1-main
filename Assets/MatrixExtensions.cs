using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MatrixExtensions
{
    public static float ConvertDegToRad(float degrees)
    {
        return ((float)Mathf.PI / (float)180) * degrees;
    }

    public static Quaternion ExtractRotation(this Matrix4x4 matrix)
    {
        Vector3 forward;
        forward.x = matrix.m02;
        forward.y = matrix.m12;
        forward.z = matrix.m22;

        Debug.Log(forward);

        Vector3 upwards;
        upwards.x = matrix.m01;
        upwards.y = matrix.m11;
        upwards.z = matrix.m21;


        return Quaternion.LookRotation(forward, upwards);
    }

    public static Vector3 ExtractPosition(this Matrix4x4 matrix)
    {
        Vector3 position;
        position.x = matrix.m03;
        position.y = matrix.m13;
        position.z = matrix.m23;
        return position;
    }

    public static Matrix4x4 Translate(this Matrix4x4 matrix, Vector3 aPosition)
    {
        var m = Matrix4x4.identity;
        m.m03 = aPosition.x;
        m.m13 = aPosition.y;
        m.m23 = aPosition.z;
        return m;
    }

    public static Vector3 ExtractScale(this Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }


    public static Matrix4x4 RotateX(float aAngleRad)
    {
        Matrix4x4 m = Matrix4x4.identity;
        m.m11 = m.m22 = Mathf.Cos(aAngleRad);
        m.m21 = Mathf.Sin(aAngleRad);
        m.m12 = -m.m21;
        return m;
    }
    public static Matrix4x4 RotateY(float aAngleRad)
    {
        Matrix4x4 m = Matrix4x4.identity;
        m.m00 = m.m22 = Mathf.Cos(aAngleRad);
        m.m02 = Mathf.Sin(aAngleRad);
        m.m20 = -m.m02;
        return m;
    }
    public static Matrix4x4 RotateZ(float aAngleRad)
    {
        Matrix4x4 m = Matrix4x4.identity;
        m.m00 = m.m11 = Mathf.Cos(aAngleRad);
        m.m10 = Mathf.Sin(aAngleRad);
        m.m01 = -m.m10;
        return m;
    }
    public static Matrix4x4 Rotate(this Matrix4x4 matrix, Quaternion aEulerAngles)
    {
        Vector3 _aEulerAngles = aEulerAngles.eulerAngles;
        var rad = _aEulerAngles * Mathf.Deg2Rad;
        return RotateY(rad.y) * RotateX(rad.x) * RotateZ(rad.z);
    }

 
   
    public static Matrix4x4 Get_TRS_Matrix(this Matrix4x4 m, Vector3 aPos, Quaternion aEuler, Vector3 aScale)
    {
        return m.Translate(aPos) * m.Rotate(aEuler) * Matrix4x4.identity;
    }

    public static Matrix4x4 Init_Matrix(this Matrix4x4 matrix, Vector3 position, Quaternion rotationAngles, Vector3 scale)
    {
        return Matrix4x4.identity;
    }
}