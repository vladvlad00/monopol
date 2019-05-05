using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class creare_tabla : MonoBehaviour
{
    const float hProp = 65F;
    const float lProp = 40F;
    const float h2Prop = 13.3F;
    const float marimeTabla = 490F;

    //Colors

    Color AlbastruInchis = new Color(8f, 116f, 189f, 255f);
    Color VerdeInchis = new Color(33f, 177f, 89f, 255f);
    Color Galben = new Color(245f, 243f, 11f, 255f);
    Color Rosu = new Color(245f, 21f, 36f, 255f);
    Color Portocaliu = new Color(245f, 147f, 31f, 255f);
    Color Roz = new Color(220f, 57f, 152f, 255f);
    Color AlbastruDeschis = new Color(174f, 226f, 248f, 255f);
    Color Maro = new Color(153f, 86f, 57f, 255f);

    //End Colors

    //Names
    public Dictionary<string, string> names = new Dictionary<string, string>();

    GameObject someGO;
    Canvas myCanvas;

    public GameObject tabla;
    public Sprite[] imagini = new Sprite[12];

    public float xTabla, yTabla, zTabla;

    // Use this for initialization
    void Start()
    {
        xTabla = tabla.transform.position.x;
        yTabla = tabla.transform.position.y + 1F;
        zTabla = tabla.transform.position.z;
        ConvertAllColors();
        //InitCanvas();
        InitTableNames();
        //DrawReper(); F for the fallen comrade, RIP
        DrawTheBlackLinesPlease();
        DrawTheRectsPlease();
        DrawTheCorners();
        DrawTheRest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    float ValAbs(float transfThis)
    {
        if (transfThis < 0) return transfThis * -1;
        return transfThis;
    }

    Color ConverColorToUnity(Color cl)
    {
        cl = new Color(cl.r / 255, cl.g / 255, cl.b / 255, cl.a / 255);
        return cl;
    }

    void ConvertAllColors()
    {
        AlbastruInchis = ConverColorToUnity(AlbastruInchis);
        VerdeInchis = ConverColorToUnity(VerdeInchis);
        Galben = ConverColorToUnity(Galben);
        Rosu = ConverColorToUnity(Rosu);
        Portocaliu = ConverColorToUnity(Portocaliu);
        Roz = ConverColorToUnity(Roz);
        AlbastruDeschis = ConverColorToUnity(AlbastruDeschis);
        Maro = ConverColorToUnity(Maro);
    }

    /*void InitCanvas()
    {
        someGO = new GameObject();
        someGO.name = "Test Canvas";
        someGO.AddComponent<Canvas>();

        myCanvas = someGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        myCanvas.transform.localScale = new Vector2(marimeTabla, marimeTabla);
        someGO.AddComponent<CanvasScaler>();
        someGO.AddComponent<GraphicRaycaster>();
    }
    */

    void InitTableNames()
    {
        names["albastru1"] = "Copou";
        names["albastru2"] = "Stefan\ncel Mare";
        names["verde1"] = "Centru";
        names["verde2"] = "Piata\nUnirii";
        names["verde3"] = "Podu\nRos";
        names["galben1"] = "Targu\nCucu";
        names["galben2"] = "Nicolina";
        names["galben3"] = "Tudor";
        names["rosu1"] = "Pacurari";
        names["rosu2"] = "Canta";
        names["rosu3"] = "Cantemir";
        names["portocaliu1"] = "Tatarasi";
        names["portocaliu2"] = "Elena\nDoamna";
        names["portocaliu3"] = "Bucium";
        names["roz1"] = "Alexandru";
        names["roz2"] = "Mircea";
        names["roz3"] = "Baza 3";
        names["bleu1"] = "Uzinei";
        names["bleu2"] = "Bularga";
        names["bleu3"] = "Dacia";
        names["maro1"] = "Galata";
        names["maro2"] = "Pacuret";
        names["util1"] = "Antibiotice";
        names["util2"] = "E-ON";
        names["gara1"] = "Gara";
        names["gara2"] = "Aeroport";
        names["gara3"] = "Gara\nNicolina";
        names["gara4"] = "Autogara";
        names["taxe1"] = "Taxa\nde Lux";
        names["taxe2"] = "Impozit\npe Venit";
        names["sansa"] = "Sansa";
        names["cufar"] = "Cufarul\nComunitatii";
    }

    void DrawLine(Vector3 start, Vector3 finish, Color cl, float wd)
    {
        GameObject linie = new GameObject();
        linie.transform.position = start;
        linie.AddComponent<LineRenderer>();
        LineRenderer lr = linie.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Custom/Gigel"));
        lr.SetColors(cl, cl);
        lr.SetWidth(wd, wd);
        lr.SetPosition(0, start);
        lr.SetPosition(1, finish);
        lr.alignment = LineAlignment.TransformZ;
        lr.transform.Rotate(90f, 0, 0f, 0f);
    }

    void DrawRect(Vector3 start, Vector3 finish, Color cl)
    {
        float xStartLinie = start.x + 1.5f;
        float xFinishLinie = finish.x - 1.5f;
        float zLinie = (start.z + finish.z) / 2;
        float wLinie = ValAbs(start.z - finish.z) - 3f;
        // s-ar putea sa trb sa pui /2, testezi acasa
        float yLinie = start.y;

        Vector3 startLinie = new Vector3(xStartLinie, yLinie, zLinie);
        Vector3 finishLinie = new Vector3(xFinishLinie, yLinie, zLinie);

        GameObject dreptunghi = new GameObject();
        dreptunghi.transform.position = startLinie;
        dreptunghi.AddComponent<LineRenderer>();
        LineRenderer lrdr = dreptunghi.GetComponent<LineRenderer>();
        lrdr.material = new Material(Shader.Find("Custom/Gigel"));
        lrdr.SetColors(cl, cl);
        lrdr.SetWidth(wLinie, wLinie);
        lrdr.SetPosition(0, startLinie);
        lrdr.SetPosition(1, finishLinie);
        lrdr.alignment = LineAlignment.TransformZ;
        lrdr.transform.Rotate(90f, 0, 0f, 0f);
        //lrdr.sortingOrder = -1;
    }

    void DrawText(Vector3 poz, string textul, int size, Color cl, float rotX, float rotY)
    {
        Font ArialF = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        GameObject myText = new GameObject();
        Font Kabel = Resources.Load<Font>("Fonts/Kabel-Heavy");
        Material KabelMat = Resources.Load<Material>("Fonts/Kabel-Heavy");

        myText.transform.position = poz;

        TextMesh plsText = myText.AddComponent<TextMesh>();

        plsText.text = textul;
        plsText.fontSize = size;
        plsText.font = Kabel;
        plsText.font.material = KabelMat;
        plsText.color = cl;
        plsText.anchor = TextAnchor.UpperCenter;
        plsText.alignment = TextAlignment.Center;
        plsText.lineSpacing = 1.5f;
        //plsText.fontStyle = FontStyle.Bold;

        MeshRenderer rend = myText.GetComponent<MeshRenderer>();
        rend.material = KabelMat;

        myText.transform.Rotate(rotX, rotY, 0f, 0f);
    }

    void DrawTheBlackLinesPlease()
    {
            DrawLine(new Vector3(xTabla + marimeTabla / 2, yTabla, zTabla + marimeTabla / 2), new Vector3(xTabla + marimeTabla / 2, yTabla, zTabla - marimeTabla / 2), Color.black, 2F);
            DrawLine(new Vector3(xTabla + marimeTabla / 2, yTabla, zTabla + marimeTabla / 2), new Vector3(xTabla - marimeTabla / 2, yTabla, zTabla + marimeTabla / 2), Color.black, 2F);
            DrawLine(new Vector3(xTabla - marimeTabla / 2, yTabla, zTabla - marimeTabla / 2), new Vector3(xTabla - marimeTabla / 2, yTabla, zTabla + marimeTabla / 2), Color.black, 2F);
            DrawLine(new Vector3(xTabla - marimeTabla / 2, yTabla, zTabla - marimeTabla / 2), new Vector3(xTabla + marimeTabla / 2, yTabla, zTabla - marimeTabla / 2), Color.black, 2F);
            //contur tabla
            DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp, yTabla, zTabla + marimeTabla / 2), new Vector3(xTabla + marimeTabla / 2 - hProp, yTabla, zTabla - marimeTabla / 2), Color.black, 2F);
            DrawLine(new Vector3(xTabla + marimeTabla / 2, yTabla, zTabla + marimeTabla / 2 - hProp), new Vector3(xTabla - marimeTabla / 2, yTabla, zTabla + marimeTabla / 2 - hProp), Color.black, 2F);
            DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp, yTabla, zTabla - marimeTabla / 2), new Vector3(xTabla - marimeTabla / 2 + hProp, yTabla, zTabla + marimeTabla / 2), Color.black, 2F);
            DrawLine(new Vector3(xTabla - marimeTabla / 2, yTabla, zTabla - marimeTabla / 2 + hProp), new Vector3(xTabla + marimeTabla / 2, yTabla, zTabla - marimeTabla / 2 + hProp), Color.black, 2F);
            //contur interior
            for (int i = 1; i <= 8; i++)
                DrawLine(new Vector3(xTabla + marimeTabla / 2, yTabla, zTabla - marimeTabla / 2 + i * lProp + hProp), new Vector3(xTabla + marimeTabla / 2 - hProp, yTabla, zTabla - marimeTabla / 2 + i * lProp + hProp), Color.black, 2F);
            for (int i = 1; i <= 8; i++)
                DrawLine(new Vector3(xTabla - marimeTabla / 2 + i * lProp + hProp, yTabla, zTabla + marimeTabla / 2), new Vector3(xTabla - marimeTabla / 2 + i * lProp + hProp, yTabla, zTabla + marimeTabla / 2 - hProp), Color.black, 2F);
            for (int i = 1; i <= 8; i++)
                DrawLine(new Vector3(xTabla - marimeTabla / 2, yTabla, zTabla - marimeTabla / 2 + i * lProp + hProp), new Vector3(xTabla - marimeTabla / 2 + hProp, yTabla, zTabla - marimeTabla / 2 + i * lProp + hProp), Color.black, 2F);
            for (int i = 1; i <= 8; i++)
                DrawLine(new Vector3(xTabla - marimeTabla / 2 + i * lProp + hProp, yTabla, zTabla - marimeTabla / 2), new Vector3(xTabla - marimeTabla / 2 + i * lProp + hProp, yTabla, zTabla - marimeTabla / 2 + hProp), Color.black, 2F);
            //contur patrate mici
            /*
            DrawLine (new Vector3 (xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp), new Vector3 (xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp), Color.black, 3F);
            DrawLine (new Vector3 (xTabla + marimeTabla / 2 - hProp, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), new Vector3 (xTabla - marimeTabla / 2 + hProp, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), Color.black, 3F);
            DrawLine (new Vector3 (xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp), new Vector3 (xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp), Color.black, 3F);
            DrawLine (new Vector3 (xTabla - marimeTabla / 2 + hProp, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), new Vector3 (xTabla + marimeTabla / 2 - hProp, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), Color.black, 3F);
            */
            // linie de sub culoare
    }

    void DrawTheRectsPlease()
    {

        float offsetText = 10F;
        int stdTextSize = 80;
        int stdTextSizeP = 80;
        float lineWd = 2F;

        #region JOS
        //Albastru1
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd)), AlbastruInchis);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 0.5F, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - lineWd), names["albastru1"], stdTextSize, Color.black, 90f, 0f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 0.5F, yTabla, zTabla - marimeTabla / 2 + h2Prop / 2 + lineWd), Base.preturi[21].ToString() + " lei", stdTextSizeP, Color.black, 90f, 0f);
        //Albastru2
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 2 - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 3 + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd)), AlbastruInchis);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 2, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 3, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 2.5F, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - lineWd), names["albastru2"], stdTextSize, Color.black, 90f, 0f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 2.5F, yTabla, zTabla - marimeTabla / 2 + h2Prop / 2 + lineWd), Base.preturi[20].ToString() + " lei", stdTextSizeP, Color.black, 90f, 0f);
        //Verde1
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 5 - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 6 + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd)), VerdeInchis);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 5, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 6, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 5.5F, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - lineWd), names["verde1"], stdTextSize, Color.black, 90f, 0f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 5.5F, yTabla, zTabla - marimeTabla / 2 + h2Prop / 2 + lineWd), Base.preturi[19].ToString() + " lei", stdTextSizeP, Color.black, 90f, 0f);
        //Verde2
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 7 - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 8 + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd)), VerdeInchis);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 7, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 8, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 7.5F, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - lineWd), names["verde2"], stdTextSize, Color.black, 90f, 0f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 7.5F, yTabla, zTabla - marimeTabla / 2 + h2Prop / 2 + lineWd), Base.preturi[18].ToString() + " lei", stdTextSizeP, Color.black, 90f, 0f);
        //Verde3
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 8 - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 9 + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd)), VerdeInchis);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 8, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 9, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 8.5F, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop - lineWd), names["verde3"], stdTextSize, Color.black, 90f, 0f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 8.5F, yTabla, zTabla - marimeTabla / 2 + h2Prop / 2 + lineWd), Base.preturi[17].ToString() + " lei", stdTextSizeP, Color.black, 90f, 0f);
        #endregion

        #region DREAPTA
        //Galben1
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp - (3F - lineWd)), Galben);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 0.5F), names["galben1"], stdTextSize, Color.black, 90f, 270f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 0.5F), Base.preturi[16].ToString() + " lei", stdTextSizeP, Color.black, 90f, 270f);
        //Galben2
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3 + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 2 - (3F - lineWd)), Galben);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 2), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 2.5F), names["galben2"], stdTextSize, Color.black, 90f, 270f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 2.5F), Base.preturi[15].ToString() + " lei", stdTextSizeP, Color.black, 90f, 270f);
        //Galben3
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 4 + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3 - (3F - lineWd)), Galben);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 4), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3.5F), names["galben3"], stdTextSize, Color.black, 90f, 270f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3.5F), Base.preturi[14].ToString() + " lei", stdTextSizeP, Color.black, 90f, 270f);
        //Rosu1
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 6 + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 5 - (3F - lineWd)), Rosu);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 6), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 5), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 5.5F), names["rosu1"], stdTextSize, Color.black, 90f, 270f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 5.5F), Base.preturi[13].ToString() + " lei", stdTextSizeP, Color.black, 90f, 270f);
        //Rosu2
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 7 + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 6 - (3F - lineWd)), Rosu);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 7), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 6), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 6.5F), names["rosu2"], stdTextSize, Color.black, 90f, 270f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 6.5F), Base.preturi[12].ToString() + " lei", stdTextSizeP, Color.black, 90f, 270f);
        //Rosu3
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 9 + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd), yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 8 - (3F - lineWd)), Rosu);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 9), new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 8), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop + lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 8.5F), names["rosu3"], stdTextSize, Color.black, 90f, 270f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 8.5F), Base.preturi[11].ToString() + " lei", stdTextSizeP, Color.black, 90f, 270f);
        #endregion

        #region SUS
        //Portocaliu1
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - (3F - lineWd)), Portocaliu);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), new Vector3(xTabla + marimeTabla / 2 - hProp, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 0.5F, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + lineWd), names["portocaliu1"], stdTextSize, Color.black, 90f, 180f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 0.5F, yTabla, zTabla + marimeTabla / 2 - h2Prop / 2 - lineWd), Base.preturi[10].ToString() + " lei", stdTextSizeP, Color.black, 90f, 180f);
        //Portocaliu2
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 2 - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - (3F - lineWd)), Portocaliu);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 2, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 1.5F, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + lineWd), names["portocaliu2"], stdTextSize, Color.black, 90f, 180f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 1.5F, yTabla, zTabla + marimeTabla / 2 - h2Prop / 2 - lineWd), Base.preturi[9].ToString() + " lei", stdTextSizeP, Color.black, 90f, 180f);
        //Portocaliu3
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 4 - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 3 + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - (3F - lineWd)), Portocaliu);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 4, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 3, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 3.5F, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + lineWd), names["portocaliu3"], stdTextSize, Color.black, 90f, 180f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 3.5F, yTabla, zTabla + marimeTabla / 2 - h2Prop / 2 - lineWd), Base.preturi[8].ToString() + " lei", stdTextSizeP, Color.black, 90f, 180f);
        //Roz1
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 6 - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 5 + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - (3F - lineWd)), Roz);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 6, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 5, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 5.5F, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + lineWd), names["roz1"], stdTextSize, Color.black, 90f, 180f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 5.5F, yTabla, zTabla + marimeTabla / 2 - h2Prop / 2 - lineWd), Base.preturi[7].ToString() + " lei", stdTextSizeP, Color.black, 90f, 180f);
        //Roz2
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 7 - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 6 + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - (3F - lineWd)), Roz);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 7, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 6, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 6.5F, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + lineWd), names["roz2"], stdTextSize, Color.black, 90f, 180f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 6.5F, yTabla, zTabla + marimeTabla / 2 - h2Prop / 2 - lineWd), Base.preturi[6].ToString() + " lei", stdTextSizeP, Color.black, 90f, 180f);
        //Roz3
        DrawRect(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 9 - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + (3F - lineWd)), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 8 + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - (3F - lineWd)), Roz);
        DrawLine(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 9, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 8, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop), Color.black, lineWd);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 8.5F, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop + lineWd), names["roz3"], stdTextSize, Color.black, 90f, 180f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 8.5F, yTabla, zTabla + marimeTabla / 2 - h2Prop / 2 - lineWd), Base.preturi[5].ToString() + " lei", stdTextSizeP, Color.black, 90f, 180f);
        #endregion

        #region STANGA
        //AlbastruDeschis1
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp - (3F - lineWd)), AlbastruDeschis);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp), new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 0.5F), names["bleu1"], stdTextSize, Color.black, 90f, 90f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + h2Prop / 2 + lineWd , yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 0.5F), Base.preturi[4].ToString() + " lei", stdTextSizeP, Color.black, 90f, 90f);
        //AlbastruDeschis2
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 2 - (3F - lineWd)), AlbastruDeschis);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp), new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 2), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 1.5F), names["bleu2"], stdTextSize, Color.black, 90f, 90f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + h2Prop / 2 + lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 1.5F), Base.preturi[3].ToString() + " lei", stdTextSizeP, Color.black, 90f, 90f);
        //AlbastruDeschis3
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 3 + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 4 - (3F - lineWd)), AlbastruDeschis);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 3), new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 4), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 3.5F), names["bleu3"], stdTextSize, Color.black, 90f, 90f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + h2Prop / 2 + lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 3.5F), Base.preturi[2].ToString() + " lei", stdTextSizeP, Color.black, 90f, 90f);
        //Maro1
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 6 + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 7 - (3F - lineWd)), Maro);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 6), new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 7), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 6.5F), names["maro1"], stdTextSize, Color.black, 90f, 90f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + h2Prop / 2 + lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 6.5F), Base.preturi[1].ToString() + " lei", stdTextSizeP, Color.black, 90f, 90f);
        //Maro2
        DrawRect(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 8 + (3F - lineWd)), new Vector3(xTabla - marimeTabla / 2 + hProp + (3F - lineWd), yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 9 - (3F - lineWd)), Maro);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 8), new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 9), Color.black, lineWd);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop - lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 8.5F), names["maro2"], stdTextSize, Color.black, 90f, 90f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + h2Prop / 2 + lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 8.5F), Base.preturi[0].ToString() + " lei", stdTextSizeP, Color.black, 90f, 90f);
        #endregion

    }
    
    void DrawReper()
    {

        float offset = 10f;

        //parcare
        DrawLine(new Vector3(xTabla + marimeTabla / 2, 0, yTabla + marimeTabla / 2), new Vector3(xTabla + marimeTabla / 2, 100, yTabla + marimeTabla / 2), Color.magenta, 3F);
        DrawText(new Vector3(xTabla + marimeTabla / 2 + offset, 50, yTabla + marimeTabla / 2 + offset), "PARCARE", 100, Color.magenta, 0, 0);
        //start
        DrawLine(new Vector3(xTabla - marimeTabla / 2, 0, yTabla - marimeTabla / 2), new Vector3(xTabla - marimeTabla / 2, 100, yTabla - marimeTabla / 2), Color.blue, 3F);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + offset, 50, yTabla - marimeTabla / 2 + offset), "START", 100, Color.blue, 0, 0);
        //jail
        DrawLine(new Vector3(xTabla - marimeTabla / 2, 0, yTabla + marimeTabla / 2), new Vector3(xTabla - marimeTabla / 2, 100, yTabla + marimeTabla / 2), Color.yellow, 3F);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + offset, 50, yTabla + marimeTabla / 2 + offset), "JAIL", 100, Color.yellow, 0, 0);
        //go to jail
        DrawLine(new Vector3(xTabla + marimeTabla / 2, 0, yTabla - marimeTabla / 2), new Vector3(xTabla + marimeTabla / 2, 100, yTabla - marimeTabla / 2), Color.cyan, 3F);
        DrawText(new Vector3(xTabla + marimeTabla / 2 + offset, 50, yTabla - marimeTabla / 2 + offset), "GO TO JAIL", 100, Color.cyan, 0, 0);
    }

    void DrawTheCorners()
    {
        float lineWd = 2F;
        float guess = h2Prop - lineWd;
        
        //Start
        GameObject start = new GameObject();
        SpriteRenderer spStart = start.AddComponent<SpriteRenderer>();
        start.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp / 2, yTabla, zTabla - marimeTabla / 2 + hProp / 2);
        spStart.sprite = imagini[5];
        spStart.transform.Rotate(90f, 45f, 0f, 0f);
        spStart.transform.localScale = new Vector3(25, 25, 25);

        //Inchisoare
        GameObject inchisoare = new GameObject();
        SpriteRenderer spInchisoare = inchisoare.AddComponent<SpriteRenderer>();
        inchisoare.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp / 2, yTabla, zTabla + marimeTabla / 2 - hProp / 2);
        spInchisoare.sprite = imagini[6];
        spInchisoare.transform.Rotate(90f, 180f, 0f, 0f);
        spInchisoare.transform.localScale = new Vector3(17, 17, 17);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + guess, yTabla, zTabla + marimeTabla / 2 - guess), new Vector3(xTabla - marimeTabla / 2 + guess, yTabla, zTabla + marimeTabla / 2 - hProp), Color.black, lineWd);
        DrawLine(new Vector3(xTabla - marimeTabla / 2 + guess, yTabla, zTabla + marimeTabla / 2 - guess), new Vector3(xTabla - marimeTabla / 2 + hProp, yTabla, zTabla + marimeTabla / 2 - guess), Color.black, lineWd);

        //Parcare
        GameObject parcare = new GameObject();
        SpriteRenderer spParcare = parcare.AddComponent<SpriteRenderer>();
        parcare.transform.position = new Vector3(xTabla + marimeTabla / 2 - hProp / 2, yTabla, zTabla + marimeTabla / 2 - hProp / 2);
        spParcare.sprite = imagini[7];
        spParcare.transform.Rotate(90f, 270f, 0f, 0f);
        spParcare.transform.localScale = new Vector3(17, 17, 17);

        //Politai
        GameObject politai = new GameObject();
        SpriteRenderer spPolitai = politai.AddComponent<SpriteRenderer>();
        politai.transform.position = new Vector3(xTabla + marimeTabla / 2 - hProp / 2, yTabla, zTabla - marimeTabla / 2 + hProp / 2);
        spPolitai.sprite = imagini[8];
        spPolitai.transform.Rotate(90f, 0f, 0f, 0f);
        spPolitai.transform.localScale = new Vector3(15, 15, 15);
    }

    void DrawTheRest()
    {
        int stdTextSize = 80;
        int stdTextSizeP = 80;
        float lineWd = 2F;
        #region Utilitati

        //Antibiotice
        GameObject util1 = new GameObject();
        SpriteRenderer sp1 = util1.AddComponent<SpriteRenderer>();
        sp1.sprite = imagini[0];
        sp1.transform.localScale = new Vector3(6, 6, 6);
        sp1.transform.Rotate(90f, 180f, 0f, 0f);
        util1.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 1.5F, yTabla, zTabla + marimeTabla / 2 - hProp / 2);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 1.5F, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop / 2), names["util1"], stdTextSize, Color.black, 90f, 180f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 1.5F, yTabla, zTabla + marimeTabla / 2 - h2Prop / 2 - lineWd), Base.preturi[22] + " lei", stdTextSizeP, Color.black, 90f, 180f);

        //E-ON
        GameObject util2 = new GameObject();
        SpriteRenderer sp2 = util2.AddComponent<SpriteRenderer>();
        sp2.sprite = imagini[1];
        sp2.transform.localScale = new Vector3(9, 9, 9);
        sp2.transform.Rotate(90f, 270f, 0f, 0f);
        util2.transform.position = new Vector3(xTabla + marimeTabla / 2 - hProp / 2, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 1.5F);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop / 2, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 1.5F), names["util2"], stdTextSize, Color.black, 90f, 270f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 1.5F), Base.preturi[22] + " lei", stdTextSizeP, Color.black, 90f, 270f);
        #endregion

        #region Gari

        //gara1
        GameObject gara1 = new GameObject();
        SpriteRenderer spg1 = gara1.AddComponent<SpriteRenderer>();
        spg1.sprite = imagini[4];
        spg1.transform.localScale = new Vector3(9, 9, 9);
        spg1.transform.Rotate(90f, 90f, 0f, 0f);
        gara1.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp / 2, yTabla, zTabla);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop / 2, yTabla, zTabla), names["gara1"], stdTextSize, Color.black, 90f, 90f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + h2Prop / 2 + lineWd, yTabla, zTabla), Base.preturi[23] + " lei", stdTextSize, Color.black, 90f, 90f);

        //gara2
        GameObject gara2 = new GameObject();
        SpriteRenderer spg2 = gara2.AddComponent<SpriteRenderer>();
        spg2.sprite = imagini[3];
        spg2.transform.localScale = new Vector3(9, 9, 9);
        spg2.transform.Rotate(90f, 180f, 0f, 0f);
        gara2.transform.position = new Vector3(xTabla, yTabla, zTabla + marimeTabla / 2 - hProp / 2);
        DrawText(new Vector3(xTabla, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop / 2), names["gara2"], stdTextSize, Color.black, 90f, 180f);
        DrawText(new Vector3(xTabla, yTabla, zTabla + marimeTabla / 2 - h2Prop / 2 - lineWd), Base.preturi[23] + " lei", stdTextSize, Color.black, 90f, 180f);

        //gara3
        GameObject gara3 = new GameObject();
        SpriteRenderer spg3 = gara3.AddComponent<SpriteRenderer>();
        spg3.sprite = imagini[4];
        spg3.transform.localScale = new Vector3(9, 9, 9);
        spg3.transform.Rotate(90f, 270f, 0f, 0f);
        gara3.transform.position = new Vector3(xTabla + marimeTabla / 2 - hProp / 2, yTabla, zTabla);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop / 2, yTabla, zTabla), names["gara3"], stdTextSize, Color.black, 90f, 270f);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - h2Prop / 2 - lineWd, yTabla, zTabla), Base.preturi[23] + " lei", stdTextSize, Color.black, 90f, 270f);

        //gara4
        GameObject gara4 = new GameObject();
        SpriteRenderer spg4 = gara4.AddComponent<SpriteRenderer>();
        spg4.sprite = imagini[2];
        spg4.transform.localScale = new Vector3(9, 9, 9);
        spg4.transform.Rotate(90f, 0f, 0f, 0f);
        gara4.transform.position = new Vector3(xTabla, yTabla, zTabla - marimeTabla / 2 + hProp / 2);
        DrawText(new Vector3(xTabla, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop / 2), names["gara4"], stdTextSize, Color.black, 90f, 0f);
        DrawText(new Vector3(xTabla, yTabla, zTabla - marimeTabla / 2 + h2Prop / 2 + lineWd), Base.preturi[23] + " lei", stdTextSize, Color.black, 90f, 0f);
        #endregion

        #region Taxe

        //De lux
        GameObject taxaLux = new GameObject();
        SpriteRenderer spTaxaLux = taxaLux.AddComponent<SpriteRenderer>();
        spTaxaLux.sprite = imagini[11];
        taxaLux.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 1.5F, yTabla, zTabla - marimeTabla / 2 + hProp / 2 - h2Prop / 2 + lineWd);
        spTaxaLux.transform.Rotate(90f, 0f, 0f, 0f);
        spTaxaLux.transform.localScale = new Vector3(7, 7, 7);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 1.5F, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop / 2 - lineWd), names["taxe1"], stdTextSize, Color.black, 90f, 0f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 1.5F, yTabla, zTabla - marimeTabla / 2 + h2Prop / 2 + lineWd), "Platesti " + Base.preturi[24] + " lei", stdTextSizeP - 20, Color.black, 90f, 0f);

        //Impozit
        GameObject taxaImp = new GameObject();
        SpriteRenderer spTaxaImp = taxaImp.AddComponent<SpriteRenderer>();
        spTaxaImp.sprite = imagini[11];
        taxaImp.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp / 2 - h2Prop / 2 + lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3.5F);
        spTaxaImp.transform.Rotate(90f, 90f, 0f, 0f);
        spTaxaImp.transform.localScale = new Vector3(7, 7, 7);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3.5F), names["taxe2"], stdTextSize, Color.black, 90f, 90f);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + h2Prop / 2 + lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 3.5F), "Platesti " + Base.preturi[25] + " lei", stdTextSizeP -20, Color.black, 90f, 90f);
        #endregion

        #region Sanse si Cufere

        //JOS
        GameObject s1 = new GameObject();
        SpriteRenderer ss1 = s1.AddComponent<SpriteRenderer>();
        s1.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 3.5F, yTabla, zTabla - marimeTabla / 2 + hProp / 2 - h2Prop / 2);
        ss1.sprite = imagini[9];
        ss1.transform.Rotate(90f, 0f, 0f, 0f);
        ss1.transform.localScale = new Vector3(10, 10, 10);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 3.5F, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop / 2 - lineWd), names["sansa"], stdTextSize, Color.black, 90f, 0f);

        GameObject c1 = new GameObject();
        SpriteRenderer sc1 = c1.AddComponent<SpriteRenderer>();
        c1.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 6.5F, yTabla, zTabla - marimeTabla / 2 + hProp / 2 - h2Prop / 2);
        sc1.sprite = imagini[10];
        sc1.transform.Rotate(90f, 0f, 0f, 0f);
        sc1.transform.localScale = new Vector3(10, 10, 10);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp + lProp * 6.5F, yTabla, zTabla - marimeTabla / 2 + hProp - h2Prop / 2 - lineWd), names["cufar"], stdTextSize, Color.black, 90f, 0f);

        //DREAPTA
        GameObject s2 = new GameObject();
        SpriteRenderer ss2 = s2.AddComponent<SpriteRenderer>();
        s2.transform.position = new Vector3(xTabla + marimeTabla / 2 - hProp / 2 + h2Prop / 2, yTabla, zTabla + marimeTabla / 2 + - hProp - lProp * 1.5F);
        ss2.sprite = imagini[9];
        ss2.transform.Rotate(90f, 270f, 0f, 0f);
        ss2.transform.localScale = new Vector3(10, 10, 10);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp + h2Prop / 2 + lineWd, yTabla, zTabla + marimeTabla / 2 + - hProp - lProp * 1.5F), names["sansa"], stdTextSize, Color.black, 90f, 270f);

        //SUS
        GameObject c2 = new GameObject();
        SpriteRenderer sc2 = c2.AddComponent<SpriteRenderer>();
        c2.transform.position = new Vector3(xTabla + marimeTabla /2 - hProp - lProp * 2.5F, yTabla, zTabla + marimeTabla / 2 - hProp / 2 + h2Prop / 2);
        sc2.sprite = imagini[10];
        sc2.transform.Rotate(90f, 180f, 0f, 0f);
        sc2.transform.localScale = new Vector3(10, 10, 10);
        DrawText(new Vector3(xTabla + marimeTabla / 2 - hProp - lProp * 2.5F, yTabla, zTabla + marimeTabla / 2 - hProp + h2Prop / 2 + lineWd), names["cufar"], stdTextSize, Color.black, 90f, 180f);

        //STANGA
        GameObject s3 = new GameObject();
        SpriteRenderer ss3 = s3.AddComponent<SpriteRenderer>();
        s3.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp / 2 - h2Prop / 2, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 2.5F);
        ss3.sprite = imagini[9];
        ss3.transform.Rotate(90f, 90f, 0f, 0f);
        ss3.transform.localScale = new Vector3(10, 10, 10);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop / 2 - lineWd, yTabla, zTabla + marimeTabla / 2 - hProp - lProp * 2.5F), names["sansa"], stdTextSize, Color.black, 90f, 90f);

        GameObject c3 = new GameObject();
        SpriteRenderer sc3 = c3.AddComponent<SpriteRenderer>();
        c3.transform.position = new Vector3(xTabla - marimeTabla / 2 + hProp / 2 - h2Prop / 2, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 1.5F);
        sc3.sprite = imagini[10];
        sc3.transform.Rotate(90f, 90f, 0f, 0f);
        sc3.transform.localScale = new Vector3(10, 10, 10);
        DrawText(new Vector3(xTabla - marimeTabla / 2 + hProp - h2Prop / 2 - lineWd, yTabla, zTabla - marimeTabla / 2 + hProp + lProp * 1.5F), names["cufar"], stdTextSize, Color.black, 90f, 90f);
        #endregion
    }
}
