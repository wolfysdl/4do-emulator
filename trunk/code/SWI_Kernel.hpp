#ifndef _INC_SWI_KERNEL
#define _INC_SWI_KERNEL

#include "types.h"
#include <cstdio>

#include "KernelTypes.hpp"
#include "DMAController.h"

///////////////////////////////////////////////////////////
// GENERAL

// kprintf
void KRN_kprintf(const char *format, int argc, void **argv);

///////////////////////////////////////////////////////////
// MEMORY

// Allocation
MemPtr KRN_malloc( int32 size );
MemPtr KRN_AllocMem( int32 s, uint32 t );//MemPtr KRN_AllocMem( int32 s, uint32 t );
MemPtr KRN_AllocMemBlocks( int32 size, uint32 typebits );
MemPtr KRN_AllocMemFromMemList( MemListPtr ml, int32 size, uint32 memflags);
MemPtr KRN_AllocMemFromMemLists( ListPtr l, int32 size, uint32 memflags);
MemListPtr KRN_AllocMemList( const MemPtr p, CharPtr name );

// Deletion
void KRN_free( MemPtr p );
void KRN_FreeMem( MemPtr p, int32 size );
void KRN_FreeMemList( MemListPtr ml );
void KRN_FreeMemToMemList( MemListPtr ml, MemPtr p, int32 size );
void KRN_FreeMemToMemLists( MemListPtr l, MemPtr p, int32 size );
int32 KRN_ScavengeMem( void );

// Memory info
void   KRN_AvailMem(MemInfoPtr minfo, uint32 memflags);
Err    KRN_ControlMem( MemPtr p, int32 size, int32 cmd, Item task );
int32  KRN_GetMemAllocAlignment( uint32 memflags );
int32  KRN_GetMemTrackSize( const MemPtr p );
uint32 KRN_GetMemType( const MemPtr p );
int32  KRN_GetPageSize( uint32 memflags );
bool   KRN_IsMemReadable( const MemPtr p, int32 size );
bool   KRN_IsMemWritable( const MemPtr p, int32 size );

// Memory debugging
Err KRN_DumpMemDebug(const TagArgPtr args);
Err KRN_CreateMemDebug(uint32 controlFlags, const TagArgPtr args);
Err KRN_DeleteMemDebug(void);
Err KRN_SanityCheckMemDebug(const TagArgPtr args);

///////////////////////////////////////////////////////////
// ITEMS

// Creating Items
Item KRN_CreateBufferedMsg( const CharPtr name, uint8 pri, Item mp, uint32 datasize );
Item KRN_CreateIOReq( const CharPtr name, uint8 pri, Item dev, Item mp );
Item KRN_CreateItem( int32 ct, TagArgPtr p );
Item KRN_CreateItemVA( int32 ct, uint32 tags, ... );
Item KRN_CreateMsg( const CharPtr name, uint8 pri, Item mp );
Item KRN_CreateMsgPort( const CharPtr name, uint8 pri, uint32 signal );
Item KRN_CreateSemaphore( const CharPtr name, uint8 pri );
Item KRN_CreateSmallMsg( const CharPtr name, uint8 pri, Item mp );
Item KRN_CreateThread( const CharPtr name, uint8 pri, FunctionPtr code, int32 stacksize );
Item KRN_CreateUniqueMsgPort( const CharPtr name, uint8 pri, uint32 signal );
Item KRN_CreateUniqueSemaphore( const CharPtr name, uint8 pri );

// Opening Items
Item KRN_FindAndOpenDevice( const CharPtr name );
Item KRN_FindAndOpenFolio( const CharPtr name );
Item KRN_FindAndOpenItem( int32 cType, TagArgPtr tp );
Item KRN_FindAndOpenItemVA( int32 cType, uint32 tags, ... );
Item KRN_FindAndOpenNamedItem( int32 ctype, const CharPtr name );
Item KRN_OpenItem( Item FoundItem, MemPtr args );
Item KRN_OpenNamedDevice( const CharPtr name, uint32 a );

// Managing Items
ItemPtr KRN_CheckItem( Item i, uint8 ftype, uint8 ntype );
Item KRN_FindDevice( const CharPtr name );
Item KRN_FindFolio( const CharPtr name );
Item KRN_FindItem( int32 cType, TagArgPtr tp );
Item KRN_FindItemVA( int32 cType, uint32 tags, ...);
Item KRN_FindMsgPort( const CharPtr name );
Item KRN_FindNamedItem( int32 ctype, const CharPtr name );
Item KRN_FindSemaphore( const CharPtr name );
Item KRN_FindTask( const CharPtr name );
Item KRN_FindVersionedItem( int32 ctype, const CharPtr name, uint8 vers, uint8 rev );
ItemPtr KRN_LookupItem( Item i );
Err KRN_SetItemOwner( Item i, Item newOwner );
int32 KRN_SetItemPri( Item i, uint8 newpri );

// Closing and Deleting Items
Err KRN_CloseItem( Item i );
Err KRN_CloseNamedDevice(Item devItem);
Err KRN_DeleteIOReq( Item item );
Err KRN_DeleteItem( Item i );
Err KRN_DeleteMsg( Item it );
Err KRN_DeleteMsgPort( Item it );
Err KRN_DeleteSemaphore( Item s );
Err KRN_DeleteThread( Item x );

#endif