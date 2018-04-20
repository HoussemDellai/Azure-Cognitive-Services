namespace ComputerVisionApplication.Models.Emotion
{

    //public class EmotionResult
    //{
    //    public FaceRectangle FaceRectangle { get; set; }
    //    public Scores Scores { get; set; }
    //}

    //public class FaceRectangle
    //{
    //    public int Left { get; set; }
    //    public int Top { get; set; }
    //    public int Width { get; set; }
    //    public int Height { get; set; }
    //}

    //public class Scores
    //{
    //    public float Anger { get; set; }
    //    public float Contempt { get; set; }
    //    public float Disgust { get; set; }
    //    public float Fear { get; set; }
    //    public float Happiness { get; set; }
    //    public float Neutral { get; set; }
    //    public float Sadness { get; set; }
    //    public float Surprise { get; set; }
    //}

    //public class Rootobject
    //{
    //    public Class1[] Property1 { get; set; }
    //}

    public class EmotionResult
    {
        public string FaceId { get; set; }
        public Facerectangle FaceRectangle { get; set; }
        public Faceattributes FaceAttributes { get; set; }
    }

    public class Facerectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Faceattributes
    {
        public float Smile { get; set; }
        public Headpose HeadPose { get; set; }
        public string Gender { get; set; }
        public float Age { get; set; }
        public Facialhair FacialHair { get; set; }
        public string Glasses { get; set; }
        public Emotion Emotion { get; set; }
        public Blur Blur { get; set; }
        public Exposure Exposure { get; set; }
        public Noise Noise { get; set; }
        public Makeup Makeup { get; set; }
        public Accessory[] Accessories { get; set; }
        public Occlusion Occlusion { get; set; }
        public Hair Hair { get; set; }
    }

    public class Headpose
    {
        public float Pitch { get; set; }
        public float Roll { get; set; }
        public float Yaw { get; set; }
    }

    public class Facialhair
    {
        public float Moustache { get; set; }
        public float Beard { get; set; }
        public float Sideburns { get; set; }
    }

    public class Emotion
    {
        public float Anger { get; set; }
        public float Contempt { get; set; }
        public float Disgust { get; set; }
        public float Fear { get; set; }
        public float Happiness { get; set; }
        public float Neutral { get; set; }
        public float Sadness { get; set; }
        public float Surprise { get; set; }
    }

    public class Blur
    {
        public string BlurLevel { get; set; }
        public float Value { get; set; }
    }

    public class Exposure
    {
        public string ExposureLevel { get; set; }
        public float Value { get; set; }
    }

    public class Noise
    {
        public string NoiseLevel { get; set; }
        public float Value { get; set; }
    }

    public class Makeup
    {
        public bool EyeMakeup { get; set; }
        public bool LipMakeup { get; set; }
    }

    public class Occlusion
    {
        public bool ForeheadOccluded { get; set; }
        public bool EyeOccluded { get; set; }
        public bool MouthOccluded { get; set; }
    }

    public class Hair
    {
        public float Bald { get; set; }
        public bool Invisible { get; set; }
        public Haircolor[] HairColor { get; set; }
    }

    public class Haircolor
    {
        public string Color { get; set; }
        public float Confidence { get; set; }
    }

    public class Accessory
    {
        public string Type { get; set; }
        public float Confidence { get; set; }
    }

}
