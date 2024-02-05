namespace ParallerLoopSampleTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            long totalSize = 0;

            //Act
            Parallel.For(0, files.Length, i =>
            {
                var fileInfo = new FileInfo(files[i]);

                Interlocked.Add(ref totalSize, (int)fileInfo.Length);
            });

            //Assert
            Assert.NotEqual(0, totalSize);
        }


        [Fact]
        public void Test2()
        {
            //Arrange
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            long totalSize = 0;

            //Act
            for (int i = 0; i < files.Length; i++)
            {
                var fileInfo = new FileInfo(files[i]);

                totalSize += fileInfo.Length;
            }

            //Assert
            Assert.NotEqual(0, totalSize);
        }
    }
}