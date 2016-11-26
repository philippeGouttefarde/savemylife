using UnityEngine;
using System.Collections;
using Vectrosity;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class LineManager : MonoBehaviour {

    public enum MODE { DRAW, CUT }

    private MODE currentMode = MODE.DRAW;

    #region INTERACTOR

    #endregion

    #region DRAWLINE
    private Vector3 previousMousePosition;
    private int index = 0;
    private List<VectorLine> vectorLines;
    private List<VectorLine> backUpLines;
    public Canvas canvas;
    public float width;
    public Texture texture;

    public Color LineColor;

    // Use this for initialization
    void Start () {
        //VectorLine.SetLine(Color.green, new Vector2(0, 0), new Vector2(Screen.width - 1, Screen.height - 1));
        //List<Vector3> test = new List<Vector3>();
        //test.Add(new Vector2(0, 0));
        //test.Add(new Vector2(Screen.width - 1, Screen.height - 1));
        //VectorLine myVectorLine = new VectorLine();
        //myVectorLine.color = Color.green;
        //myVectorLine.Draw();
        //myVectorLine.po
        vectorLines = new List<VectorLine>();
        backUpLines = new List<VectorLine>();

    }

    private void DrawLine()
    {
        if (Input.GetButtonDown("mouse 0"))
        {
            //GameObject line = new GameObject("line_"+index);
            VectorLine line = new VectorLine("line_" + index, new List<Vector2>(), texture, width, LineType.Continuous, Joins.None);

            //Vector2 pos;
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, Camera.main, out pos);
            line.SetCanvas(canvas);
            ////transform.position = myCanvas.transform.TransformPoint(pos);
            line.points2.Add(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            line.color = LineColor;

            vectorLines.Add(line);
        }
        if (Input.GetButton("mouse 0"))
        {

            //Vector2 pos;
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, Camera.main, out pos);
            Vector3 currentPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            print(currentPosition + "+++++" + previousMousePosition);
            if (currentPosition != previousMousePosition)
            {
                vectorLines[index].points2.Add(currentPosition);
                vectorLines[index].Draw();
                print("I'm supposed to be drawing");
            }
            previousMousePosition = currentPosition;
        }

        if (Input.GetButtonUp("mouse 0"))
        {
            index++;
        }
    }

    // Update is called once per frame
    private void DragAndDropCut()
    {

    }

    // Update is called once per frame
    void Update () {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (currentMode == MODE.DRAW) {
                DrawLine();
            } else
            {
                DragAndDropCut();
            }
        }
    }

    private void SetCurrentModePencil()
    {
        this.currentMode = MODE.DRAW;
    }


    private void SetCurrentModeCut()
    {
        this.currentMode = MODE.CUT;
    }

    public void undo()
    {
        if (vectorLines != null && vectorLines.Count>0)
        {
            VectorLine objectToDestroy = vectorLines[index - 1];
            VectorLine backupLine = new VectorLine(objectToDestroy.name, objectToDestroy.points2, texture, objectToDestroy.lineWidth, objectToDestroy.lineType, Joins.None);
            
            backUpLines.Add(backupLine);
            VectorLine.Destroy(ref objectToDestroy);
            vectorLines.RemoveAt(index - 1);
            index--;
        }
    }

    public void redo()
    {
        if (backUpLines != null && backUpLines.Count > 0)
        {
            VectorLine lineToRestore = backUpLines[backUpLines.Count-1];
            lineToRestore.color = LineColor;
            vectorLines.Add(lineToRestore);

            lineToRestore.Draw();
            backUpLines.RemoveAt(backUpLines.Count - 1);
            index++;
        }
    }

    public void clearAll()
    {
        if (vectorLines != null && vectorLines.Count > 0)
        {
            for(int i = index-1; i>=0;i--)
            {
                VectorLine objectToDestroy = vectorLines[i];
                VectorLine.Destroy(ref objectToDestroy);
                vectorLines.RemoveAt(i);
            }
            index = 0;
        }

        if (backUpLines != null && backUpLines.Count > 0)
        {
            for (int i = backUpLines.Count - 1; i >= 0; i--)
            {
                VectorLine objectToDestroy = backUpLines[i];
                VectorLine.Destroy(ref objectToDestroy);
                backUpLines.RemoveAt(i);
            }
            index = 0;
        }
    }
    #endregion

}
