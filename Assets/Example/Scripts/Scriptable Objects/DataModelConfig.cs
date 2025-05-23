using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DataModelConfig", menuName = "Data/Data Model Config")]
public class DataModelConfig : ScriptableObject
{
    public UserProfileModel userProfileModel;
    public SettingsModel settingsModel;
    public List<IDataModel> DefaultModels = new List<IDataModel>();

    [Inject]
    public void Init()
    {
        DefaultModels.Add(userProfileModel);
        DefaultModels.Add(settingsModel);
    }

#if UNITY_EDITOR
    public void AddDefaultModel(IDataModel model)
    {
        if (model == null) return;

        if (!DefaultModels.Contains(model))
        {
            DefaultModels.Add(model);
            UnityEditor.EditorUtility.SetDirty(this);
        }
    }
#endif
}