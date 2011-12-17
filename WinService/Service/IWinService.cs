
namespace Service {
    /// <summary>
    /// This interface is for Runner classes that can be startable.
    /// Used for running in service mode or running in console mode.
    /// </summary>
    public interface IStartable {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start();
    }
}
