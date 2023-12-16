using UnityEngine;

public class ResetLists : MonoBehaviour
{
    public void Reset()
    {
        var listPaint = PaintingPower.Instance.Paintings;
        var listGraffiti = GraffitiPower.Instance.Graffitis;

        //foreach (var item in listGraffiti)
        //{
        //    Destroy(item);
        //}
        //foreach (var item in listPaint)
        //{
        //    Destroy(item);
        //}
        //listGraffiti.RemoveAll(t => t == null);
        //listPaint.RemoveAll(t => t == null);

        for (int i = 0; i < listPaint.Count;)
        {
            Destroy(listPaint[0]);
            listPaint.RemoveAt(0);
        }
        for (int i = 0; i < listGraffiti.Count;)
        {
            Destroy(listGraffiti[0]);
            listGraffiti.RemoveAt(0);
        }
    }
}
