﻿namespace POC.Grpc.App.Application.Models.Error;

public class ErrorViewModel
{
    public string RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}