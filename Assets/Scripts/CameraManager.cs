using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;

namespace CASP.CameraManager
{

    public class CameraManager : MonoBehaviour
    {
        public static CameraManager instance;

        [SerializeField] CinemachineBrain Brain;
        // [SerializeField] List<CinemachineVirtualCamera> VCamList;
        Dictionary<string, CinemachineVirtualCamera> Cams = new Dictionary<string, CinemachineVirtualCamera>();
        [SerializeField] List<StructCam> Camslist;
        private void Awake() {
            if (instance == null) {
                instance = this;
            }
        }
        void Start()
        {
            foreach (Transform camTransform in transform)
            {
                if (camTransform.TryGetComponent<CinemachineVirtualCamera>(out CinemachineVirtualCamera vCam)) {
                    // VCamList.Add(vCam);
                    AddCamera(vCam, Cams, Camslist);
                }
            }
        }

        void AddCamera(CinemachineVirtualCamera _vCam, Dictionary<string, CinemachineVirtualCamera> _camDict, List<StructCam> _camsList) {
            // Struct Add
            StructCam s = new StructCam();
            s.Key = _vCam.name;
            s.Value = _vCam;
            _camsList.Add(s);

            // Dictionary Add
            _camDict.Add(_vCam.name, _vCam);
        }

        public void OpenCamera(string CameraName) {

            Cams.FirstOrDefault(x=>x.Key == CameraName).Value.Priority = 11;

            foreach (var item in Cams)
            {
                // item.Value.Priority = item.Key == CameraName ? 11 : 10;
                if (item.Key != CameraName) {
                    item.Value.Priority = 10;
                }
            }
        }

        public void OpenCamera(string CameraName, float Time, CameraEaseStates CameraEase) {
            Brain.m_DefaultBlend.m_Time = Time;
            Brain.m_DefaultBlend.m_Style = (CinemachineBlendDefinition.Style)CameraEase;
            // if(Cams ==null)
            //     return;
            Cams.FirstOrDefault(x=>x.Key == CameraName).Value.Priority = 11;

            foreach (var item in Cams)
            {
                // item.Value.Priority = item.Key == CameraName ? 11 : 10;
                if (item.Key != CameraName) {
                    item.Value.Priority = 10;
                }
            }
        }

        public void SetFollow(string CameraName, Transform ObjectTransform) {
            Cams.FirstOrDefault(x=>x.Key == CameraName).Value.Follow = ObjectTransform;
        }

        public void SetLookAt(string CameraName, Transform ObjectTransform) {
            Cams.FirstOrDefault(x=>x.Key == CameraName).Value.LookAt = ObjectTransform;
        }
    }

    [System.Serializable]
    public struct StructCam
    {
        public string Key;
        public CinemachineVirtualCamera Value;
    }

    public enum CameraEaseStates
    {
      Cut = 0,
      EaseInOut = 1,
      EaseIn = 2,
      EaseOut = 3,
      HardIn = 4,
      HardOut = 5,
      Linear = 6,
      Custom = 7
    }
}