using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CUtillity
{
#if UNITY_EDITOR
    /// <summary>
    /// 에디터용 데이터베이스 Scriptable Object를 갱신하기 위한 출력 패스
    /// </summary>
    public static string databaseExportPath = "Assets/Database/"; //"Assets/Resources/Database/";

    /// <summary>
    /// 에디터용 테이블 CSV 를 읽기 위한 패스
    /// </summary>
    public static string tableImportPath = "Assets/Table/";

    /// <summary>
    /// 에디터용 번들 출력 패스
    /// </summary>
    public static string assetBundlePath = "Assets/Bundles/";
#else
    /// <summary>
    /// 번들 출력 패스
    /// </summary>
    public static string assetBundlePath = Application.persistentDataPath + "/Brunhild/Bundles/";
#endif
}
