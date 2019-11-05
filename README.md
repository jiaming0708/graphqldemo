# 介紹
示範如何使用 `.Net Core 3` 架設 `GraphQL`，並且使用 `Angular` 作為前端框架串接

可以根據commit來一步一步的了解每一個階段應該要怎麼實作

前後端分為兩個專案
* backend (.net core)
* frontend (angular)

# backend (.Net Core)
`EF Core 3` 搭配 `GraphQL 3` 作為範例，示範如何在 `.Net Core 3` 中使用 `GraphQL` 的技術

從 `EF` 的建置一路到 `GraphQL` 建置都有放進去commit之中，大家可以一步一步的跟著操作

## package介紹
|name|version|
|---|---|
|Microsoft.EntityFrameworkCore|3.0.0|
|Microsoft.EntityFrameworkCore.Sqlite|3.0.0|
|GraphQL|3.0.0-preview-1282|
|GraphQL.Server.Transports.AspNetCore|3.5.0-alpha0033|

## 目錄結構
- Controllers: restAPI接口
- GraphModels: 所有GraphQL需要用到的物件設定
- Models: DB物件定義
- Reporsitories: EF資料串接

## 執行
可以使用 cli 指令（請記得切換目錄），或者使用 VS 執行
> dotnet run watch

# frontend (Angular)
使用 `apollo-angular` 套件連接 graphql server

## 設定
backend的url設定為 `https://localhost:5001/graphql`
> 若endpoint不同請到 `graphql.module.ts` 中的 uri 修改

## 執行
> yarn start

# 參考
* [EF教學](https://docs.microsoft.com/zh-tw/ef/core/get-started/?tabs=netcore-cli)
* [GraphQL 官方文件](https://graphql.org/)
* [GraphQL for .NET](https://github.com/graphql-dotnet/graphql-dotnet)
* [GraphQL for .NET - Subscription Transport WebSockets](https://github.com/graphql-dotnet/server)
* [Apollo Angular](https://www.apollographql.com/docs/angular/basics/setup/)
* [GraphQL for .NET sample project1](https://github.com/JacekKosciesza/StarWars)
* [GraphQL for .NET sample project2](https://github.com/graphql-dotnet/examples)
* [GraphQL 你好你好](https://medium.com/inside-codementor/graphql-%E4%BD%A0%E5%A5%BD%E4%BD%A0%E5%A5%BD-8a0ffbe702c7)