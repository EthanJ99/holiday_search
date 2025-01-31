using System;

namespace DataReadService;

public interface IReadData<T>
{
    // Abstract JSON reading class for multiple types of JSON (e.g. suitable for Hotel and Flight data)
    static abstract List<T> ReadData(string filepath);
}
