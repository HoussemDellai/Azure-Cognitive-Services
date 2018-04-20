using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CognitiveServices.Models;
using ComputerVisionApplication.Models;
using ComputerVisionApplication.Models.Emotion;
using Newtonsoft.Json;

namespace CognitiveServices.Services
{
    /// <summary>
    /// Client for Computer Vision API (Microsoft Cognitive Services).
    /// </summary>
    public class EmotionService
    {

        /// <summary>
        /// Get a subscription key from:
        /// https://www.microsoft.com/cognitive-services/en-us/subscriptions
        /// </summary>
        private readonly string _key = "2a180527dd884af38ef011bf2879cf1a";
        /// <summary>
        /// Documentation: https://dev.projectoxford.ai/docs/services/5639d931ca73072154c1ce89/operations/563b31ea778daf121cc3a5fa
        /// </summary>
        private readonly string _recognizeEmotionsUri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect" +
                                                        "?returnFaceId=true&returnFaceLandmarks=false" +
                                                        "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

        /// <summary>
        /// Get a subscription key from:
        /// https://www.microsoft.com/cognitive-services/en-us/subscriptions
        /// </summary>
        /// <param name="key">subscription key: required to access the API</param>
        public EmotionService(string key)
        {
            _key = key;
        }
        /// <summary>
        /// Recognizes the emotions expressed by one or more people in an image, 
        /// as well as returns a bounding box for the face. 
        /// The emotions detected are happiness, sadness, surprise, anger, fear, 
        /// contempt, and disgust or neutral. 
        /// </summary>
        /// <param name="imageUrl">The image url.</param>
        /// <returns></returns>
        public async Task<List<EmotionResult>> RecognizeEmotionsFromImageUrlAsync(string imageUrl)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);

            var stringContent = new StringContent(@"{""url"":""" + imageUrl + @"""}");

            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var response = await httpClient.PostAsync(_recognizeEmotionsUri, stringContent);

                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var imageResultEmotions = JsonConvert.DeserializeObject<List<EmotionResult>>(json);

                    return imageResultEmotions;
                }

                throw new Exception(json);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Recognizes the emotions expressed by one or more people in an image, 
        /// as well as returns a bounding box for the face. 
        /// The emotions detected are happiness, sadness, surprise, anger, fear, 
        /// contempt, and disgust or neutral. 
        /// </summary>
        /// <param name="stream">The image stream.</param>
        /// <returns></returns>
        public async Task<List<EmotionResult>> RecognizeEmotionsFromImageStreamAsync(Stream stream)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);

            var streamContent = new StreamContent(stream);

            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            try
            {
                var response = await httpClient.PostAsync(_recognizeEmotionsUri, streamContent);

                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {

                    var imageResultEmotions = JsonConvert.DeserializeObject<List<EmotionResult>>(json);

                    return imageResultEmotions;
                }

                throw new Exception(json);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
