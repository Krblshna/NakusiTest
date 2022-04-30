namespace NakusiTest.Common
{
    public interface IRemainderIndicator
    {
        void OnChange(float delta);
        void Init(float curAmount, float maxAmount);
    }
}