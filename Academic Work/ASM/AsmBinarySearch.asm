TITLE AsmBinarySearch Procedure (AsmBinarySearch.asm)
COMMENT %
This program is a modul built to compare speed of using C++ vs ASM to perform a Binary
Search on a fixed set of numbers.
%

	.586
	.model flat,C

	AsmBinarySearch PROTO, searchValue:DWORD, arrayPTR:PTR DWORD, count:DWORD

	.data

	.code
	;----------------------------------------------------------
	AsmBinarySearch PROC USES ebx edx esi edi,
		searchValue:DWORD, 
		arrayPTR:PTR DWORD, 
		count:DWORD
	LOCAL first:DWORD,
		last:DWORD,
		mid:DWORD
	;
	; Performs a binary search for a 32 - bit integer
	; in an array of integers. Returns the value of the subscript
	; of the matching array element in EAX, or -1 in EAX if the
	; search value was not found in the array.
	; 
	; 
	; ----------------------------------------------------------

		mov	 first,0			; first = 0
		mov	 eax,count			; last = (count - 1)
		dec	 eax
		mov	 last,eax			; mov value into variable
		mov	 edi,searchValue	; edi = searchValue
		mov	 ebx,arrayPTR		; ebx points to the array

	L1: ; while first <= last
		mov	 eax,first
		cmp	 eax,last
		jg	 notFound			; jump to exit with notFound return value

	; mid = (last + first) / 2
		mov	 eax,last
		add	 eax,first	
		shr	 eax,1				; divide by two
		mov	 mid,eax			; mov into variable

	; edx = numbers[mid]
		mov	 esi,mid			; mov mid index into esi
		mov	 edx,[ebx+esi*4]	; edx = values[mid]

	; if ( edx < searchvalue(edi) )
	;	first = mid + 1;
		cmp	 edx,edi			; 
		jge	 L2					; if >= then try <= in L2 
		mov	 eax,mid			; first = mid + 1
		inc	 eax
		mov	 first,eax
		jmp	 L1					; start main loop over

	; else if( edx > searchValue(edi) )
	;	last = mid - 1;
	L2:	cmp	 edx,edi
		jle	 found				; if <= AND >= then just == so the value has been found
		mov	 eax,mid			; move on if not equal
		dec	 eax				; last = mid - 1
		mov	 last,eax			; 
		jmp	 L1					; Start main moop over

	; else return mid
	found:	
		mov	eax,mid  			; value found
		jmp	 short omega		; return (mid)

	notFound:
		mov	eax,-1				; Set the return value to indicate that
		jmp	short omega			; the search value was not found.

omega:
	ret							; return
AsmBinarySearch ENDP
END
