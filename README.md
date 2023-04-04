# Keyset Pagination vs. Offset Pagination

This repository contains a benchmarking project that compares Keyset Pagination and Offset Pagination in C# using LINQ and BenchmarkDotNet. Keyset Pagination and Offset Pagination are two common pagination techniques used in web applications to retrieve a subset of data from a database for display in a user interface. The project provides a sample implementation of both pagination techniques and uses BenchmarkDotNet to measure and compare their performance.

The benchmarking project includes a sample C# application that simulates a simple data retrieval scenario, where data is retrieved from an in-memory collection. The project uses BenchmarkDotNet, a popular benchmarking library for .NET, to measure the execution time and memory usage of both Keyset Pagination and Offset Pagination. The benchmark results are presented in a tabular format, allowing for easy comparison of the performance of the two pagination techniques.

In addition to the benchmarking project, the repository also includes a README.md file that provides a detailed explanation of Keyset Pagination and Offset Pagination, their advantages and disadvantages, and a comparison of their performance based on the benchmark results. The README.md file is written in English and serves as a documentation for the benchmarking project, providing insights and guidance on choosing the appropriate pagination technique based on specific application requirements.

The goal of this repository is to provide developers with a benchmarking tool to compare the performance of Keyset Pagination and Offset Pagination in a C# application, and to help them make informed decisions on which pagination technique to use in their own projects. It is intended to be a useful resource for developers who are interested in understanding the differences between Keyset Pagination and Offset Pagination, and their implications in terms of performance and functionality. Contributions and feedback are welcome to further improve and enhance this benchmarking project.

## Keyset Pagination

Keyset Pagination, also known as "seek method" or "cursor-based pagination", is a pagination technique that relies on a unique and ordered column in the database table to determine the starting point for retrieving the next page of results. In Keyset Pagination, the last value of the unique column in the current page is used as the starting point to fetch the next page. This allows for efficient pagination as it does not depend on the page number or offset, and it can handle dynamic changes in the data set.

### Advantages of Keyset Pagination

- Efficient and performant for large datasets: Keyset Pagination can perform well on large datasets as it does not require calculating an offset or skipping a fixed number of rows, which can be slow with large data sets.
- Stable and consistent results: Keyset Pagination provides stable and consistent results even when new data is added or removed from the dataset between pagination requests, as it relies on the unique and ordered column to determine the next page.
- Scalable: Keyset Pagination can be used with various database systems, and it is scalable as it does not rely on the page number or offset.

### Disadvantages of Keyset Pagination

- Complexity: Implementing Keyset Pagination can be more complex than Offset Pagination as it requires understanding the unique and ordered column and how it affects pagination.
- Not suitable for arbitrary access: Keyset Pagination is not suitable for arbitrary access to pages, as it relies on the last value of the unique column to determine the starting point for the next page.
- Database-dependent: Keyset Pagination may require different implementations or optimizations depending on the specific database system being used.

## Offset Pagination

Offset Pagination, also known as "skip and take" or "limit and offset" pagination, is a pagination technique that uses a fixed number of rows to determine the starting point and the number of rows to fetch for each page. In Offset Pagination, the page number or the offset is calculated based on the page size and used to skip a fixed number of rows in the query, which can be inefficient for large datasets.

### Advantages of Offset Pagination

- Simplicity: Offset Pagination is relatively simple to implement as it only requires calculating the page number or offset based on the page size.
- Suitable for arbitrary access: Offset Pagination allows for arbitrary access to pages, as the page number or offset can be easily calculated for any page.
- Database-independent: Offset Pagination can be used with various database systems, and it does not rely on any specific unique or ordered column.

### Disadvantages of Offset Pagination

- Performance issues with large datasets: Offset Pagination can suffer from performance issues with large datasets, as it requires calculating the page number or offset and skipping a fixed number of rows, which can be slow with large data sets.
- Inconsistent results with dynamic data changes: Offset Pagination can produce inconsistent results when new data is added or removed from the dataset between pagination requests, as the page number or offset may no longer align with the actual data.

## Conclusion

In conclusion, both Keyset Pagination and Offset Pagination have their advantages and disadvantages. Keyset Pagination can be more efficient and performant for large datasets, and it provides stable and consistent results. However, it may be more complex to implement and may require database-dependent optimizations. On the other hand, Offset Pagination is relatively simple to implement and suitable for arbitrary access to pages, but it can suffer from performance issues with large datasets and may produce inconsistent results with dynamic data changes. The choice between Keyset Pagination and Offset Pagination should be made based on the specific requirements and constraints of the application, such as the size of the dataset, performance considerations, and database system being used. It's important to carefully evaluate the pros and cons of each pagination technique and choose the one that best fits the needs of your application.

## Benchmark Result

|           Method | ItemCount |             Mean |          Error |         StdDev |
|----------------- |---------- |-----------------:|---------------:|---------------:|
| KeysetPagination |      1000 |         2.891 us |      0.0248 us |      0.0232 us |
| OffsetPagination |      1000 |       255.784 us |      2.8173 us |      2.6353 us |
| KeysetPagination |     10000 |        28.657 us |      0.2134 us |      0.3060 us |
| OffsetPagination |     10000 |    31,538.175 us |    528.1918 us |    494.0710 us |
| KeysetPagination |    100000 |       256.836 us |      2.6373 us |      2.3379 us |
| OffsetPagination |    100000 | 2,478,336.271 us | 24,927.1801 us | 22,097.2959 us |
