using System;
using ObjCRuntime;

[assembly: LinkWith("libPushSDK-1.8.3.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
    SmartLink = true, 
    ForceLoad = true,
    Frameworks = "CFNetwork CoreFoundation CoreTelephony SystemConfiguration CoreGraphics Foundation UIKit Security",
    LinkerFlags = "-lz")]
