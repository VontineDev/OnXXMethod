using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; //Json을 사용하겠다
using System.IO;
using UnityEngine.UI;
public enum fileState { SAVE, LOAD };
public class FileManager : MonoBehaviour
{
    #region NotUsedNow
    //public Button btnSaveTxt;       // btn to save txt file
    //public Button btnLoadTxt;       // btn to load txt from file
    //public Button btnSaveImg;       // btn to save img file
    //public Button btnLoadImg;       // btn to load img from file
    #endregion

    public fileState fileState;

    public Button btnSave;
    public Button btnLoad;


    public Image sourceImage;
    public Image loadedImage;

    string folderPath;
    string txtFilePath;
    string imgFilePath;
    int[] imgsize;

    public Text txtInfo; //shows infomation to screen





    private void Start()
    {
        folderPath = Application.persistentDataPath + "/saves";
        txtFilePath = "/save.json";
        imgFilePath = "/img.png";

        imgsize = new int[2];

        btnSave.onClick.AddListener(() =>
        {
            SaveFile();
        });

        btnLoad.onClick.AddListener(() =>
        {
            LoadFile();
        });

        #region AnotherButton
        //btnSaveTxt.onClick.AddListener(() =>
        //{
        //    SaveFile();
        //});
        //btnLoadTxt.onClick.AddListener(() =>
        //{
        //    LoadFile();
        //});
        //btnSaveImg.onClick.AddListener(() =>
        //{
        //    SaveImage();
        //});
        //btnLoadImg.onClick.AddListener(() =>
        //{
        //    LoadImage();
        //});
        #endregion
    }

    public void ShowProgressTxt()
    {

    }
    public void SaveFile()
    {
        SaveFilesInfo info = new SaveFilesInfo();

        info.name = "돼지";
        info.age = 4;
        info.phoneNumber = "01012345678";

        SaveImage();

        info.width = imgsize[0];
        info.height = imgsize[1];
        info.imgPath = folderPath + imgFilePath;
        var v = JsonUtility.ToJson(info);

        File.WriteAllText(folderPath + txtFilePath, v);

        //SaveFormat test = new SaveFormat();
        //var t = JsonUtility.ToJson(test);
        //File.WriteAllText(folderPath + txtFilePath, t);
    }

    public void LoadFile()
    {
        if (File.Exists(folderPath + txtFilePath))
        {
            var str = File.ReadAllText(folderPath + txtFilePath);
            var jsInfo = JsonConvert.DeserializeObject<SaveFilesInfo>(str);

            var infoStr = $"{jsInfo.name} {jsInfo.age} {jsInfo.phoneNumber}";

            txtInfo.text = infoStr;
            imgsize[0] = jsInfo.width;
            imgsize[1] = jsInfo.height;

            LoadImage(jsInfo.imgPath, loadedImage, imgsize);
        }
    }

    void SaveImage()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var img = sourceImage.sprite.texture;
        imgsize[0] = img.width;
        imgsize[1] = img.height;
        var bytes = img.EncodeToPNG();
        File.WriteAllBytes(folderPath + imgFilePath, bytes);
    }
    public void LoadImage(string path, Image loadedImage, int[] imgsize)
    {
        var bytes = File.ReadAllBytes(path);

        var texture = new Texture2D(imgsize[0], imgsize[1]);
        texture.LoadImage(bytes);

        Sprite sp = Sprite.Create(texture, new Rect(0, 0, imgsize[0], imgsize[1]), new Vector2(0.5f, 0), 1);

        loadedImage.sprite = sp;
    }
}
