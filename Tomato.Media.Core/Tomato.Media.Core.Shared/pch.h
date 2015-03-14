﻿#pragma once
#define NOMINMAX
#include <functional>
#include <cassert>
#include <mutex>

#include <ppltasks.h>

#include "targetver.h"

#ifndef WIN32_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN
#endif

#include <windows.h>

#include <wrl.h>
#include <windows.media.h>

// WASAPI
#include <Audioclient.h>
#include <mmdeviceapi.h>

// Media Foundation
#include <mftransform.h>
#include <mfapi.h>
#include <mfidl.h>
#include <mfreadwrite.h>
#include <mferror.h>

namespace wrl = Microsoft::WRL;