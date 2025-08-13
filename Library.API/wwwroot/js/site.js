function setupImagePreview(inputId, previewId) {
    const input = document.getElementById(inputId);
    const preview = document.getElementById(previewId);

    if (!input || !preview) return;

    input.addEventListener('input', () => {
        const url = input.value.trim();
        if (url) {
            preview.src = url;
            preview.classList.remove('d-none');
        } else {
            preview.src = '#';
            preview.classList.add('d-none');
        }
    });
}

setupImagePreview('imageUrlInput', 'imagePreview');
