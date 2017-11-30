using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VortexStudios.PostProcessing;

namespace VortexStudios.PostProcessing {
    public class OLDTVPreset : ScriptableObject {
        [SerializeField]
        private NoiseProfile _noiseFilter = new NoiseProfile();
        public NoiseProfile noiseFilter { get { return _noiseFilter; } }
        [SerializeField]
        private CompositeProfile _compositeFilter = new CompositeProfile();
        public CompositeProfile compositeFilter { get { return _compositeFilter; } }
        [SerializeField]
        private StaticProfile _staticFilter = new StaticProfile();
        public StaticProfile staticFilter { get { return _staticFilter; } }
        [SerializeField]
        private TelevisionProfile _televisionFilter = new TelevisionProfile();
        public TelevisionProfile televisionFilter { get { return _televisionFilter; } }
        [SerializeField]
        private ChromaticAberrationProfile _chromaticAberrationFilter = new ChromaticAberrationProfile();
        public ChromaticAberrationProfile chromaticAberrationFilter { get { return _chromaticAberrationFilter; } }
        [SerializeField]
        private ScanlineProfile _scanlineFilter = new ScanlineProfile();
        public ScanlineProfile scanlineFilter { get { return _scanlineFilter; } }
        [SerializeField]
        private TubeProfile _tubeFilter = new TubeProfile();
        public TubeProfile tubeFilter { get { return _tubeFilter; } }

        void OnEnable() {
            _noiseFilter.OnEnable();
            _compositeFilter.OnEnable();
            _staticFilter.OnEnable();
            _televisionFilter.OnEnable();
            _chromaticAberrationFilter.OnEnable();
            _scanlineFilter.OnEnable();
            _tubeFilter.OnEnable();
        }
    }
}